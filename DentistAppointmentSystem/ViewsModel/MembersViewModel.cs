using DentistAppointmentSystem.Models;

namespace DentistAppointmentSystem.ViewModels
{
    public class MembersViewModel
    {
        public IEnumerable<ApplicationUser> Members { get; set; } = new List<ApplicationUser>();
        public string MemberGroup { get; set; } = string.Empty;
    }
}