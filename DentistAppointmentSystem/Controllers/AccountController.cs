using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DentistAppointmentSystem.Data;
using DentistAppointmentSystem.Models;
using DentistAppointmentSystem.ViewModels;
using DentistAppointmentSystem.Utilities;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DentistAppointmentSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment webHostEnvironment,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment; // Inject IWebHostEnvironment to get the web root path
        }

        // GET: /Account/GetLoginView
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Validate the view model
            if (!ModelState.IsValid) return View(model);

            try
            {
                // Validate the User credentials from the view model
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false
                );

                // If the User credentials are valid redirect to the Index action of the Home controller
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    // Set TempData for toastr notification
                    TempData["Message"] = $"Welcome, {user!.FirstName} {user.LastName}!";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");

                return View(model);
                // return RedirectToAction("Index", "Home");

            }
        }

        // GET: /Account/Logout
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");
                return View();
            }

        }

        // GET: /Account/GetRegisterView
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                // Create a new user with the provided details
                var user = new ApplicationUser
                {
                    UserName = UsernameGenerator.GenerateUsername(model.FirstName, model.LastName),
                    // UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Gender = model.Gender,
                    EmmergencyContact = model.EmmergencyContact,
                    EmmergencyContactName = model.EmmergencyContactName,
                };

                // var result = await _userManager.CreateAsync(user, "Helloworld10!");
                var result = await _userManager.CreateAsync(user, PasswordGenerator.GeneratePassword(model.FirstName, model.LastName));
                var roleResult = await _userManager.AddToRoleAsync(user, model.Role);

                if (result.Succeeded && roleResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    TempData["Message"] = $"new user {user.FirstName} {user.LastName}, created";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, $"Error: {error.GetType().Name}\t Description: {error.Description}");
                    }

                    return View(model);

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");

                return View(model);
            }
        }

        // GET: /Account/GetUpdateView
        [HttpGet]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> Update(string id)
        {
            if (id == null) return NotFound();

            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var role = (await _userManager.GetRolesAsync(user!)).FirstOrDefault();
                var model = new UserViewModel
                {
                    User = user!,
                    Role = role!
                };

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");
                // Get the url of the previous page
                var returnUrl = HttpContext.Request.Headers["Referer"].ToString();

                // Redirect to previous url or home page
                return Redirect(returnUrl ?? "/");
            }
        }

        // POST: /Account/Update
        [HttpPost]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            if (!ModelState.IsValid) return View("Update", model);

            try
            {
                // Retrieve the ID of the current user
                var currentUserId = _userManager.GetUserId(User);
                var currentUser = await _userManager.FindByIdAsync(currentUserId!);

                if (currentUser == null) return NotFound();

                // Get the role of the current user
                var currentUserRole = (await _userManager.GetRolesAsync(currentUser)).FirstOrDefault();
                // Retrieve the user being edited
                var member = await _userManager.FindByIdAsync(model.User.Id);

                if (member == null) return NotFound();

                // Get the role of the member being edited
                var memberRole = (await _userManager.GetRolesAsync(member)).FirstOrDefault();

                // Check if the current user is a Receptionist and if they are trying to edit a user with a role they shouldn't
                string[] restrictedRoles = { "Admin", "Receptionist", "Dentist" };
                if (currentUserRole == "Receptionist" && restrictedRoles.Contains(memberRole))
                {
                    TempData["Failure"] = "You are not authorised to edit this member.";

                    return RedirectToAction("Index", "Home");
                }

                // Update the member details
                member.FirstName = model.User.FirstName;
                member.LastName = model.User.LastName;
                member.DateOfBirth = DateTime.SpecifyKind(model.User.DateOfBirth, DateTimeKind.Utc);
                member.Address = model.User.Address;
                member.Gender = model.User.Gender;
                member.EmmergencyContact = model.User.EmmergencyContact;

                // Save changes
                var result = await _userManager.UpdateAsync(member);

                if (result.Succeeded)
                {
                    TempData["Message"] = $"{member.FirstName} {member.LastName} Account successfuly updated";

                    return RedirectToAction("Profile", "User", new { id = member.Id });
                }
                else
                {
                    // Add errors to ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {error.GetType().Name}\t Description: {error.Description}");
                    }
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");

                return View(model);
            }
        }

        // DELETE: /Account/Delete
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            try
            {
                var user = await _userManager.FindByIdAsync(id);
                TempData["Message"] = "Member successfuly deleted";

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                var returnUrl = HttpContext.Request.Headers["Referer"].ToString();
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");

                // Redirect to previous url or home page
                return Redirect(returnUrl ?? "/");
            }
        }

        // POST:  /Account/UpdateProfilePhoto
        [HttpPost]
        [Authorize(Roles = "Patient, Dentist, Receptionist, Admin")]
        public async Task<IActionResult> UpdateProfilePhoto(IFormFile profilePhoto)
        {
            if (profilePhoto == null || profilePhoto.Length == 0)
            {
                TempData["Failure"] = "No file selected.";
                return RedirectToAction("Profile", "User");
            }

            try
            {
                var currentUserId = _userManager.GetUserId(User);
                var currentUser = await _userManager.FindByIdAsync(currentUserId!);

                if (currentUser == null)
                {
                    TempData["Failure"] = "User not found.";
                    return RedirectToAction("Index", "Home");
                }

                // Set the folder path where the files will be stored
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists

                // Create a unique file name for the uploaded file
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + profilePhoto.FileName;
                string profilePhotoPath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save the file to the server
                using (var fileStream = new FileStream(profilePhotoPath, FileMode.Create))
                {
                    await profilePhoto.CopyToAsync(fileStream);
                }

                currentUser.ProfilePhotoPath = $"/uploads/{uniqueFileName}";

                var result = await _userManager.UpdateAsync(currentUser);

                TempData["message"] = result.Succeeded
                    ? "Profile photo successfuly updated."
                    : "Profile photo update unsuccessful. Please try again.";

                return RedirectToAction("Profile", "User", new { id = currentUserId });
            }
            catch (Exception ex)
            {
                var returnUrl = HttpContext.Request.Headers["Referer"].ToString();
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");

                // Redirect to previous url or home page
                return Redirect(returnUrl ?? "/");
            };
        }
    }
}