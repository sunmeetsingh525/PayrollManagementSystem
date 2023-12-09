using System.ComponentModel.DataAnnotations;

namespace PayrollManagementSystem.Model.Models
{
    public class Payroll
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, select employee.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please, provide working day.")]
        public int NumberOfDaysWorked { get; set; }

        [Required(ErrorMessage = "Please, provide deductions amount.")]
        public double Deductions { get; set; }

        [Required(ErrorMessage = "Please, provide total payment.")]
        public double TotalPayment { get; set; }

        public Employee Employee { get; set; }
    }
}