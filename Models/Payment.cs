namespace WebApplication4.Models
{
    public class Payment
    {
        public int PaymentId { get; set; } // PK
        public int ContractId { get; set; } // FK
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentDocument { get; set; }

        public Contract? Contract { get; set; }
    }
}
