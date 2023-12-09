using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Model.Models
{
    public class Employee
    {
        public Employee()
        {
            Payrolls = new HashSet<Payroll>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provide code.")]
        [StringLength(30, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please, provide first name.")]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, provide last name.")]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, provide phone number.")]
        [StringLength(30, MinimumLength = 2)]
        public string PhoneNumber { get; set; }
        public string RelationshipStatus { get; set; }

        [Required(ErrorMessage = "Please, select gender.")]
        public int GenderId { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "Please, provide daily rate.")]
        public double DailyRate { get; set; }

        [Required(ErrorMessage = "Please, select payment method.")]
        public int PaymentMethodId { get; set; }

        public string? ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Gender Gender { get; set; }  
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }  
    }
}