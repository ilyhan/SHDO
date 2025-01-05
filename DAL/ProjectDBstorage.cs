using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.DAL
{
    public class ProjectDBstorage
    {
        private readonly ApplicationDbContext _context;
        public ProjectDBstorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConstructionProject>> getAllProject()
        {
            return await _context.ConstructionProjects.ToListAsync();
        }

        public async Task<ConstructionProject> FindById(int? id)
        {
            return await _context.ConstructionProjects.FindAsync(id);
        }

        public void AddProject(ConstructionProject constr)
        {
            _context.ConstructionProjects.Add(constr);
            _context.SaveChanges();
        }

        public void UpgradeProject(ConstructionProject constr) 
        {
            _context.Update(constr);
            _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var constr = await FindById(id);

            _context.ConstructionProjects.Remove(constr);
            await _context.SaveChangesAsync();
        }

        public async Task<ConstructionProject> getProjectBuild(int? id)
        {
            return await _context.ConstructionProjects
                .Include(p => p.Buildings)
                .FirstOrDefaultAsync(p => p.ProjectId == id);
        }
    }
}
