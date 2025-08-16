using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models.ViewModels
{
    public class StudentListViewModel
    {
        public int id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Email Address")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        // Additional properties can be added here if needed

    }
}
