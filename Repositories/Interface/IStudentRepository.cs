using StudentManagement.Models.Entities;
using static StudentManagement.Repositories.Interface.IRepository;

namespace StudentManagement.Repositories.Interface
{
    // Fix: Ensure IRepository is generic by using IRepository<T> instead of IRepository
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
