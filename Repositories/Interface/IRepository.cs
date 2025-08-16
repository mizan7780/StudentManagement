namespace StudentManagement.Repositories.Interface
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            Task<List<T>> GetAllAsync();
            Task<T?> GetByIdAsync(int id);
            void Add(T student);
            void Update(T student);
            void Delete(T student);
            IQueryable<T> Query();
        }
    }
}
