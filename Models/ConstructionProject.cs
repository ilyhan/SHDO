using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ConstructionProject
    {
        [Key]
        public int ProjectId { get; set; } // PK
        public string Name { get; set; }
        public string District { get; set; }
        public string Infrastructure { get; set; }

        public ICollection<Building>? Buildings { get; set; }
    }
}
