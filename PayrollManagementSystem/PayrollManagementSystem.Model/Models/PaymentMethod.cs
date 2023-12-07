namespace PayrollManagementSystem.Model.Models
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
            PaymentMethods = new HashSet<PaymentMethod>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}