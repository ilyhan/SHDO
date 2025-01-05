using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using WebApplication4.DAL;

namespace WebApplication4.Controllers
{
    public class ConstructionProjectController : Controller
    {
        private readonly ProjectDBstorage _projectDBstorage;

        public ConstructionProjectController(ApplicationDbContext context)
        {
            _projectDBstorage = new ProjectDBstorage(context);
        }

        public async Task<IActionResult> Index()
        {
            var constr = await _projectDBstorage.getAllProject();
            return View(constr);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConstructionProject constr)
        {
            _projectDBstorage.AddProject(constr);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constr = await _projectDBstorage.FindById(id);
            if (constr == null)
            {
                return NotFound();
            }
            return View(constr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ConstructionProject constr)
        {
            try
            {
                _projectDBstorage.UpgradeProject(constr);
            }
            catch
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectDBstorage.getProjectBuild(id);

            if (project == null)
            {
                return NotFound();
            }

            if (project.Buildings != null && project.Buildings.Any())
            {
                return BadRequest("Невозможно удалить проект, так как существуют связанные здания.");
            }

            _projectDBstorage.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
