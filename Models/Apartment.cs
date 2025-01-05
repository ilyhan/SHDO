using System.Diagnostics.Contracts;

namespace WebApplication4.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; } // PK
        public int? BuildingId { get; set; } // FK
        public int Rooms { get; set; }
        public int Floor { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public byte[]? Photo { get; set; }

        public Building Building { get; set; }
        public Contract? Contract { get; set; }
    }
}
