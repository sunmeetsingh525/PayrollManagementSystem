using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Model.ViewModels
{
    public class PayrollCreateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, select employee.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please, provied working day.")]
        public int NumberOfDaysWorked { get; set; }

        [Required(ErrorMessage = "Please, provied deductions amount.")]
        public double Deductions { get; set; }

        [Required(ErrorMessage = "Please, provied total payment.")]
        public double TotalPayment { get; set; }
    }
}