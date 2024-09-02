using System;

namespace DentistAppointmentSystem.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Scheduled";
    }
}