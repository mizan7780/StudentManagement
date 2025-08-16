using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.UnitOfWorks.Interface;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interface;
using StudentManagement.Services.Model;

namespace StudentManagement.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Student student)
        {
             _unitOfWork.studentRepository.Add(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _unitOfWork.studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                _unitOfWork.studentRepository.Delete(student);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _unitOfWork.studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _unitOfWork.studentRepository.GetByIdAsync(id);
        }

        public async Task<List<Student>> GetFilteredStudentListAsync(FilterStudentModel filter)
        {
            var query = _unitOfWork.studentRepository.Query();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(s => EF.Functions.Like(s.FirstName + " " + s.LastName, $"%{filter.Name}%"));
            }
            

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _unitOfWork.studentRepository.Update(student);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
