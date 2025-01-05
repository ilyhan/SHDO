using System.Diagnostics.Contracts;

namespace WebApplication4.Models
{
    public class Client
    {
        public int ClientId { get; set; } // PK
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PassportData { get; set; }
        public string Phone { get; set; }

        public ICollection<Contract>? Contracts { get; set; }
    }
}
