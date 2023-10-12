using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Codesome.Models;

namespace Codesome.Data
{
    public class CodesomeContext : DbContext
    {
        public CodesomeContext (DbContextOptions<CodesomeContext> options)
            : base(options)
        {
        }

        // private readonly string connectionString = "";
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
     
          //      optionsBuilder.UseMySQL("Server=localhost;User ID=raga;Password=root;Database=codesome;");
        //}

        public DbSet<Codesome.Models.Course> Course { get; set; } = default!;

        // private readonly string connectionString = "";
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
     
          //      optionsBuilder.UseMySQL("Server=localhost;User ID=raga;Password=root;Database=codesome;");
        //}

        public DbSet<Codesome.Models.Student> Student { get; set; } = default!;
    }
}
