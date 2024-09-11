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

        public IActionResult Index()
        {

            return View();
            // return RedirectToAction("Index", "NotFound");
        }
        [Authorize(Roles = "Dentist,Admin,Receptionist, Patient")]
        public async Task<IActionResult> Profile(string id)
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

        [HttpGet]
        [Authorize(Roles = "Dentist,Admin,Receptionist, Patient")]
        public async Task<IActionResult> Appointments(AppointmentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    // var appointments = await 
                }
                // Check if the user is in one of the allowed roles
                return View(model);

            }
            return RedirectToAction("Error", "Home");
        }
    }

}

