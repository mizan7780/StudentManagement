using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.ViewModels;

namespace StudentManagement.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Entities.Student> Students { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Entities.Student>().ToTable("Students");
            modelBuilder.Entity<Models.Entities.Student>().HasKey(s => s.id);
            modelBuilder.Entity<Models.Entities.Student>().Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Models.Entities.Student>().Property(s => s.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Models.Entities.Student>().Property(s => s.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Models.Entities.Student>().Property(s => s.DOB).IsRequired();

            // Seed data
            modelBuilder.Entity<Models.Entities.Student>().HasData(
                new Models.Entities.Student
                {
                    id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@gmail.com",
                    DOB = new DateTime(2000, 1, 1)
                },
                new Models.Entities.Student
                {
                    id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane@gmail.com",
                    DOB = new DateTime(2001, 2, 2)
                },
                new Models.Entities.Student
                {
                    id = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice@gmail.com",
                    DOB = new DateTime(2002, 3, 3)
                }
            );
        }
        public DbSet<StudentManagement.Models.ViewModels.StudentCreateViewModel> StudentCreateViewModel { get; set; } = default!;
        public DbSet<StudentManagement.Models.ViewModels.StudentEditViewModel> StudentEditViewModel { get; set; } = default!;
        public DbSet<StudentManagement.Models.ViewModels.StudentListViewModel> StudentListViewModel { get; set; } = default!;
    }
}
