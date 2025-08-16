using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models.Entities
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
    }
}
