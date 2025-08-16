using StudentManagement.Models.Entities;
using StudentManagement.Services.Model;

namespace StudentManagement.Services.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<List<Student>> GetFilteredStudentListAsync(FilterStudentModel filter);
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
    }
}
