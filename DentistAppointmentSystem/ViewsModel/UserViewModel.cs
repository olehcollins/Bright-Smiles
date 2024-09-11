using DentistAppointmentSystem.Models;

namespace DentistAppointmentSystem.ViewModels
{
    public class UserViewModel
    {
        public ApplicationUser User { get; set; }
        public string Role { get; set; } = "";
    }
}