using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using WebApplication4.Models.ViewModels;
using WebApplication4.DAL;

namespace WebApplication4.Controllers
{
    public class BuildingController : Controller
    {
        private readonly BuildingDBstorage _buildingDBstorage;
        private readonly ProjectDBstorage _projectDBstorage;
        public BuildingController(ApplicationDbContext context)
        {
            _buildingDBstorage = new BuildingDBstorage(context);
            _projectDBstorage = new ProjectDBstorage(context); 
        }

        public async Task<IActionResult> Index()
        {
            var constr = await _buildingDBstorage.getAllBuilding();
            return View(constr);
        }

        public async Task<IActionResult> Create()
        {
            var constr = await _projectDBstorage.getAllProject();
            var viewModel = new BuildingModel
            {
                Building = new Building(),
                constr = constr
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BuildingModel model)
        {
            model.Building.ConstructionProject = await _projectDBstorage.FindById(model.Building.ProjectId);

            _buildingDBstorage.AddBuilding(model.Building);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var building = await _buildingDBstorage.getBuildingApart(id);

            if (building == null)
            {
                return NotFound();
            }

            if (building.Apartments != null && building.Apartments.Any())
            {
                return BadRequest("Cannot delete building");
            }

            _buildingDBstorage.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
