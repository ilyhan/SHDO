using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DAL;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Models.ViewModels;

namespace WebApplication4.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly ApartmentDBstorage _apartmentDBstorage;
        private readonly BuildingDBstorage _buildingDBstorage;

        
        public ApartmentController(ApplicationDbContext context)
        {
            _apartmentDBstorage = new ApartmentDBstorage(context);
            _buildingDBstorage = new BuildingDBstorage(context);   
        }

        public async Task<IActionResult> Index()
        {
            var apart = await _apartmentDBstorage.getAllApartment();
            return View(apart);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Apartment apart, IFormFile layout)
        {
            var build = await _buildingDBstorage.FindById(apart.BuildingId);
            if (build == null)
            {
                return BadRequest("Дома с таким id не существует");
            }

            if (layout != null)
            {
                using (var fs = layout.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    await fs.CopyToAsync(ms);
                    apart.Photo = ms.ToArray();
                }
            }

            _apartmentDBstorage.AddApartment(apart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var apartment = await _apartmentDBstorage.getApartmentContract(id);

            if (apartment == null)
            {
                return NotFound();
            }

            if (apartment.Contract != null)
            {
                return BadRequest("Cannot delete apartment");
            }

            _apartmentDBstorage.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
