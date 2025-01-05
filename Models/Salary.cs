namespace WebApplication4.Models
{
    public class Salary
    {
        public int SalaryId { get; set; } // PK
        public int? EmployeeId { get; set; } // FK
        public DateTime IssueDate { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Bonus { get; set; }

        public Employee? Employee { get; set; }
    }
}
