using Deco_Sara.dbcontext__;
using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Subcategoryservice : ISubcategoryservice
    {
        private readonly Appdbcontext _context;

        public Subcategoryservice(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Subcategory> subcategorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var query = _context.Subcategories
                                  .Include(v => v.Category);
            var TotalCount = await query.CountAsync();
            var subcategorys = await query.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (subcategorys, TotalCount);
        }
        public async Task<List<Subcategory>> GetSubcatlist()
        {

            return await _context.Subcategories.ToListAsync();
        }

        public async Task<Subcategory> GetByIdAsync(int id)
        {
            return await _context.Subcategories.FindAsync(id);
        }

        public async Task<Subcategory> AddAsync(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            await _context.SaveChangesAsync();
            return await _context.Subcategories
                          .Include(s => s.Category) // Include Category data
                          .FirstOrDefaultAsync(s => s.Subcategory_Id == subcategory.Subcategory_Id);
        }
        public async Task<Subcategory?> UpdateAsync(int id, Subcategory updatedsubcategory)
        {

            var existingSubcategory = await _context.Subcategories.FindAsync(id);
            if (existingSubcategory == null)
            {
                return null;
            }

            existingSubcategory.Subcategory_name = updatedsubcategory.Subcategory_name;
            existingSubcategory.Subcategory_description = updatedsubcategory.Subcategory_description;
            existingSubcategory.Subcategory_image = updatedsubcategory.Subcategory_image;



            await _context.SaveChangesAsync();

            return existingSubcategory;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Subcategories.FindAsync(id);
            if (category == null) return false;

            _context.Subcategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Subcategory>> GetAllSearchAsync(string search)
        {
            var query = _context.Subcategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.Subcategory_name.Contains(search));

            }

            return await query.ToListAsync();
        }

    }  
}
