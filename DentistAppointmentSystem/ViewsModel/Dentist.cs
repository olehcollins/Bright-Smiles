using DentistAppointmentSystem.Models;

namespace DentistAppointmentSystem.ViewModels
{
    public class DentistViewModel
    {
        public IEnumerable<ApplicationUser> Dentists { get; set; }
    }
}