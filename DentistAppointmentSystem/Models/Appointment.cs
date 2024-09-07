using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistAppointmentSystem.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Foreign Key for Patient
        [ForeignKey("PatientId")]
        public ApplicationUser? Patient { get; set; } // Navigation property

        // Foreign Key for Dentist
        [ForeignKey("DentistId")]
        public ApplicationUser? Dentist { get; set; } // Navigation property

        // Foreign Key for ScheduledBy
        [ForeignKey("ScheduledById")]
        public ApplicationUser? ScheduledBy { get; set; } // Navigation property

        public DateTime AppointmentDate { get; set; } = DateTime.Now;

        // Foreign Key fields
        public string PatientId { get; set; } = string.Empty; // Foreign key field
        public string DentistId { get; set; } = string.Empty; // Foreign key field
        public string ScheduledById { get; set; } = string.Empty; // Foreign key field
    }
}