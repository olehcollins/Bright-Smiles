using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DentistAppointmentSystem.Models;
using DentistAppointmentSystem.ViewModels;

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
    }

}

