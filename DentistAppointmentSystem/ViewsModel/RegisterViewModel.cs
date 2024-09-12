using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DentistAppointmentSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{0,2}?[-.\s]?(\d{7,15})$",
        ErrorMessage = "Please enter a valid phone contact number with an optional country code.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{0,2}?[-.\s]?(\d{7,15})$",
        ErrorMessage = "Please enter a valid emergency contact number with an optional country code.")]
        public string EmmergencyContact { get; set; } = string.Empty;

        [Required]
        public string EmmergencyContactName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

    }
}