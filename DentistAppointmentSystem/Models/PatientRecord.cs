using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DentistAppointmentSystem.Models;

namespace DentistAppointmentSystem.Models
{
    public class PatientRecord
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("PatientId")]
        public ApplicationUser? Patient { get; set; }

        [Required]
        public string FilePath { get; set; } = string.Empty; // Path or URL to the document

        public DateTime UploadedOn { get; set; } = DateTime.UtcNow;

        public string PatientId { get; set; } = string.Empty; // Foreign key field
    }
}