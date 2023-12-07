using Microsoft.AspNetCore.Identity;

namespace PayrollManagementSystem.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Employees = new HashSet<Employee>();    
        }

        public string? City { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}