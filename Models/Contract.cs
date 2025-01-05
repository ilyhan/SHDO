namespace WebApplication4.Models
{
    public class Contract
    {
        public int ContractId { get; set; } // PK
        public int? ClientId { get; set; } // FK
        public int ApartmentId { get; set; } // FK
        public string ContractType { get; set; }
        public DateTime ContractDate { get; set; }
        public int? EmployeeId { get; set; } // FK

        public Client? Client { get; set; }
        public Apartment Apartment { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
