using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayrollManagementSystem.Model.Models;

namespace PayrollManagementSystem.Model.DatabaseContect
{
    public class PayrollManagementSystemContext : IdentityDbContext<ApplicationUser>
    {
        public PayrollManagementSystemContext()
        {
            
        }

        public PayrollManagementSystemContext(DbContextOptions<PayrollManagementSystemContext> options) : 
            base(options) 
        {
            
        }

        public DbSet<Gender> Genders { get; set; }  
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}