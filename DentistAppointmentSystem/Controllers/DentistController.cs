using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DentistAppointmentSystem.Models;
using DentistAppointmentSystem.ViewModels;

namespace DentistAppointmentSystem.Controllers
{
    public class DentistController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DentistController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            // Ensure the role exists
            var roleExists = await _roleManager.RoleExistsAsync("Dentist");
            if (!roleExists)
            {
                // Handle the case where the role doesn't exist
                return View(new UsersViewModel { Users = Enumerable.Empty<ApplicationUser>() });
            }

            // Get users with the 'Dentist' role
            var role = await _roleManager.FindByNameAsync("Dentist");
            Console.WriteLine(role);
            var usersInRole = await _userManager.GetUsersInRoleAsync(role!.Name!);

            // Create the view model
            var model = new UsersViewModel
            {
                Users = usersInRole
            };

            // Return the view with the view model
            return View(model);
        }
    }
}