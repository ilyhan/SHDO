using System.Diagnostics.Contracts;

namespace WebApplication4.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; } // PK
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public string WorkPhone { get; set; }

        public ICollection<Contract>? Contracts { get; set; }
        public ICollection<Salary>? Salaries { get; set; }
    }
}
