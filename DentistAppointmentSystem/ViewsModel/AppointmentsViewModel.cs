using DentistAppointmentSystem.Models;

namespace DentistAppointmentSystem.ViewModels
{
    public class AppointmentsViewModel
    {
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}