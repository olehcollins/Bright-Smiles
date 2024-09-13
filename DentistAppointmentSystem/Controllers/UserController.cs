using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DentistAppointmentSystem.Models;
using DentistAppointmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Runtime;

namespace DentistAppointmentSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        [Authorize(Roles = "Dentist, Admin, Receptionist, Patient")]
        public async Task<IActionResult> Staff(string role)
        {
            try
            {
                // Get users with the for that role
                var usersInRole = await _userManager.GetUsersInRoleAsync(role);
                // Create the view model
                var model = new MembersViewModel { Members = usersInRole, MemberGroup = role };

                return View(model);
            }
            catch (Exception ex)
            {
                var returnUrl = HttpContext.Request.Headers["Referer"].ToString();
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");

                // Redirect to previous url or home page
                return Redirect(returnUrl ?? "/");
            }
        }

        // GET: User/Profile
        [HttpGet]
        [Authorize(Roles = "Dentist, Admin, Receptionist, Patient")]
        public async Task<IActionResult> Profile(string id)
        {
            if (id == null) return NotFound();

            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var role = (await _userManager.GetRolesAsync(user!)).FirstOrDefault();
                var model = new UserViewModel { User = user!, Role = role! };

                return View(model);
            }
            catch (Exception ex)
            {
                var returnUrl = HttpContext.Request.Headers["Referer"].ToString();
                ModelState.AddModelError(string.Empty, $"An error occurred while processing your request. Please try again later.\n Error: {ex.GetType().Name}\t message: {ex.Message}");

                // Redirect to previous url or home page
                return Redirect(returnUrl ?? "/");
            }
        }

        // GET: User/Appointments
        [HttpGet]
        [Authorize(Roles = "Dentist, Admin, Receptionist, Patient")]
        public async Task<IActionResult> Appointments(AppointmentsViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (User.IsInRole("Admin"))
            {
                // var appointments = await 
            }
            // Check if the user is in one of the allowed roles
            return View(model);
        }
    }
}

