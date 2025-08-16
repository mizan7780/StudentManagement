using StudentManagement.Data;
using StudentManagement.Models.Entities;
using StudentManagement.Repositories.Interface;
using static StudentManagement.Repositories.Interface.IRepository;

namespace StudentManagement.Repositories.Implementation
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        
        // Fix: Removed the base(context) call as the base class 'object' does not have a constructor.
        public StudentRepository(StudentDbContext context) : base(context)
        {
        }

        
    }
}
