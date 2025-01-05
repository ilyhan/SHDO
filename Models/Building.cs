namespace WebApplication4.Models
{
    public class Building
    {
        public int BuildingId { get; set; } // PK
        public int? ProjectId { get; set; } // FK
        public string Location { get; set; }
        public string WallMaterial { get; set; }
        public int Floors { get; set; }
        public string Street { get; set; }

        public ConstructionProject? ConstructionProject { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}
