namespace WebApplication4.Models.ViewModels
{
    public class BuildingModel
    {
        public Building? Building { get; set; }
        public IEnumerable<ConstructionProject>? constr { get; set; }
    }
}
