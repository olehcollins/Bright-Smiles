using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DentistAppointmentSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty; // Custom property
        public string LastName { get; set; } = string.Empty;  // Custom property
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;  // Custom property
        public string ProfilePhotoPath { get; set; } = string.Empty; // Custom property
        // Collection of Patient Records
        public ICollection<PatientRecord> PatientRecords { get; set; } = new List<PatientRecord>();

    }
}