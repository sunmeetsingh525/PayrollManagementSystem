using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Model.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied code.")]
        [StringLength(30, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please, provied first name.")]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, provied last name.")]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, provied phone number.")]
        [StringLength(30, MinimumLength = 2)]
        public string PhoneNumber { get; set; }
        public string RelationshipStatus { get; set; }

        [Required(ErrorMessage = "Please, select gender.")]
        public int GenderId { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "Please, provied daily rate.")]
        public double DailyRate { get; set; }

        [Required(ErrorMessage = "Please, select payment method.")]
        public int PaymentMethodId { get; set; }

        public string? ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Gender Gender { get; set; }  
        public PaymentMethod PaymentMethod { get; set; }
    }
}