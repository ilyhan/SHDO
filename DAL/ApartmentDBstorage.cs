using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.DAL
{
    public class ApartmentDBstorage
    {
        private readonly ApplicationDbContext _context;
        public ApartmentDBstorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Apartment>> getAllApartment()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment> FindById(int? id)
        {
            return await _context.Apartments.FindAsync(id);
        }

        public void AddApartment(Apartment apart)
        {
            _context.Apartments.Add(apart);
            _context.SaveChanges();
        }

        public async Task DeleteById(int id)
        {
            var apart = await FindById(id);

            _context.Apartments.Remove(apart);
            await _context.SaveChangesAsync();
        }

        public async Task<Apartment> getApartmentContract(int? id)
        {
            return await _context.Apartments
                .Include(a => a.Contract)
                .FirstOrDefaultAsync(a => a.ApartmentId == id);
        }
    }
}
