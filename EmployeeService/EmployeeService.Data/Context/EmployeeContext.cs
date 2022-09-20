using EmployeeService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data.Context
{
    public class EmployeeContext : DbContext
    {

        public virtual DbSet<Employee> Employees { get; set; }


        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");
            });

        }
    }
}
