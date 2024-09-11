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

        // REGISTER

        // GET: /Account/Login
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
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false
                );

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        // Set TempData for toastr notification
                        TempData["Message"] = $"Welcome, {user.FirstName} {user.LastName}!";
                    }
                    return RedirectToAction("Index", "Home"); // Redirect to home or another page after successful login
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // REGISTER
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // UPDATE
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new user with the provided details
                var user = new ApplicationUser
                {
                    UserName = UsernameGenerator.GenerateUsername(model.FirstName, model.LastName),
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                var result = await _userManager.CreateAsync(user, PasswordGenerator.GeneratePassword(model.FirstName, model.LastName));
                var roleResult = await _userManager.AddToRoleAsync(user, model.Role);

                if (result.Succeeded && roleResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    TempData["Message"] = $"new user {user.FirstName} {user.LastName}, created";
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        // UPDATE
        [HttpGet]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            var role = (await _userManager.GetRolesAsync(user!)).FirstOrDefault();

            var model = new UserViewModel
            {
                User = user!,
                Role = role!
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            // Retrieve the ID of the current user
            var currentUserId = _userManager.GetUserId(User);
            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            if (currentUser == null)
            {
                return NotFound();
            }

            // Get the role of the current user
            var currentUserRole = (await _userManager.GetRolesAsync(currentUser)).FirstOrDefault();

            // Retrieve the user being edited
            var member = await _userManager.FindByIdAsync(model.User.Id);
            if (member == null)
            {
                return NotFound();
            }

            // Get the role of the member being edited
            var memberRole = (await _userManager.GetRolesAsync(member)).FirstOrDefault();

            // Check if the current user is a Receptionist and if they are trying to edit a user with a role they shouldn't
            string[] restrictedRoles = { "Admin", "Receptionist", "Dentist" };
            if (currentUserRole == "Receptionist" && restrictedRoles.Contains(memberRole))
            {
                TempData["Message"] = "You are not authorised to edit this member.";
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

            // Add errors to ModelState
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("Update", model);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            TempData["Message"] = "Member successfuly deleted";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Patient, Dentist, Receptionist, Admin")]
        public async Task<IActionResult> UpdateProfilePhoto(IFormFile profilePhoto)
        {
            if (profilePhoto == null || profilePhoto.Length == 0)
            {
                TempData["message"] = "No file selected.";
                return RedirectToAction("Profile", "User");
            }

            var currentUserId = _userManager.GetUserId(User);
            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            if (currentUser == null)
            {
                TempData["message"] = "User not found.";
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

    }
}