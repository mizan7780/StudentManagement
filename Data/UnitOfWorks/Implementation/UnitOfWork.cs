using StudentManagement.Data.UnitOfWorks.Interface;
using StudentManagement.Repositories.Interface;

namespace StudentManagement.Data.UnitOfWorks.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentDbContext _context;

        public UnitOfWork(StudentDbContext context, IStudentRepository studentRepository)
        {
            _context = context;
            Students = studentRepository;
        }

        public IStudentRepository Students { get; }

        // Explicit implementation of the interface member
        IStudentRepository IUnitOfWork.studentRepository => Students;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
