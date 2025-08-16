using StudentManagement.Repositories.Interface;

namespace StudentManagement.Data.UnitOfWorks.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository studentRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
