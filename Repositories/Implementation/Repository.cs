using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using static StudentManagement.Repositories.Interface.IRepository;

namespace StudentManagement.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class // Added 'where T : class' constraint to fix CS0452
    {
        private readonly DbSet<T> _dbSet;

        public Repository(StudentDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public void Add(T product)
        {
            _dbSet.Add(product);
        }

        public void Delete(T product)
        {
            _dbSet.Remove(product);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable().AsNoTracking();
        }

        public void Update(T bloodDonor)
        {
            _dbSet.Update(bloodDonor);
        }
    }
}
