using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.DAL
{
    public class BuildingDBstorage
    {
        private readonly ApplicationDbContext _context;
        public BuildingDBstorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Building>> getAllBuilding()
        {
            return await _context.Buildings.Include(a => a.ConstructionProject).ToListAsync();
        }

        public async Task<Building> FindById(int? id)
        {
            return await _context.Buildings.FindAsync(id);
        }

        public void AddBuilding(Building build)
        {
            _context.Buildings.Add(build);
            _context.SaveChanges();
        }

        public async Task DeleteById(int id)
        {
            var build = await FindById(id);

            _context.Buildings.Remove(build);
            await _context.SaveChangesAsync();
        }

        public async Task<Building> getBuildingApart(int? id)
        {
            return await _context.Buildings
                .Include(b => b.Apartments)
                .FirstOrDefaultAsync(b => b.BuildingId == id);
        }
    }
}
