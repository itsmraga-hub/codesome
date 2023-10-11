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

        public DbSet<Codesome.Models.Course> Course { get; set; } = default!;
    }
}
