using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Course> Course { get; set; } = default!;

        public DbSet<Lesson> Lesson { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<StudentEnrollment> Enrollments { get; set; } = null!;
    }
}
