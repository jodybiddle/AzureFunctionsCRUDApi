using AzureFunctionsCRUDApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsCRUDApi
{
    public class JobDBContext : DbContext
    {
        public JobDBContext(DbContextOptions<JobDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeJob> EmployeeJob { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(4, 2); // Set precision and scale for decimal
            modelBuilder.Entity<Job>()
                .Property(p => p.Budget)
                .HasPrecision(14, 2); // Set precision and scale for decimal
            modelBuilder.Entity<Employee>()
                .Property(p => p.Salary)
                .HasPrecision(14, 2); // Set precision and scale for decimal
        }
    }
    
}
    