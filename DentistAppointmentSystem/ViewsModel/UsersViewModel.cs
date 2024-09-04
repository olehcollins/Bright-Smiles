using DentistAppointmentSystem.Models;

namespace DentistAppointmentSystem.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}