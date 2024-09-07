using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DentistAppointmentSystem.Models;
using DentistAppointmentSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DentistAppointmentSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
            // return RedirectToAction("Index", "NotFound");
        }
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserViewModel
            {
                User = user
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

