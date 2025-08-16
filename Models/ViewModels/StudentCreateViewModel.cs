using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models.ViewModels
{
    public class StudentCreateViewModel
    {
        public int id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Email Address")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [DisplayName("Date of birth")]
        public DateTime DOB { get; set; }
    }
}
