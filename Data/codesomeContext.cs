using Microsoft.EntityFrameworkCore;
using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data
{
    public class codesomeContext : DbContext
    {
        public codesomeContext (DbContextOptions<codesomeContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<StudentEnrollment> Enrollments { get; set; } = null!;
        public DbSet<CourseCategory> CourseCategories { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
