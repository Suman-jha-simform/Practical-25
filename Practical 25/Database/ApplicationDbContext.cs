using Microsoft.EntityFrameworkCore;
using Practical_25.Model;
using System.Collections.Generic;

namespace Practical_25.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
    }
}
