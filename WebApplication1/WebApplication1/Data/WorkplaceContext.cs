using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data
{
    public class WorkplaceContext : DbContext
    {
        public WorkplaceContext(DbContextOptions<WorkplaceContext> options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }
}
