using Deco_Sara.dbcontext__;
using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Categoriesservice:ICategoryservice
    {
        private readonly Appdbcontext _context;

        public Categoriesservice(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Category> categorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var TotalCount = await _context.Categories.CountAsync();
            var categorys = await _context.Categories.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (categorys, TotalCount);
        }
        public async Task<List<Category>> Getcatlist()
        {

            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category?> UpdateAsync(int id, Category updatedCategories)
        {
            
            var existingCategories = await _context.Categories.FindAsync(id);
            if (existingCategories == null)
            {
                return null; 
            }

            existingCategories.Category_name = updatedCategories.Category_name;
            existingCategories.Category_description = updatedCategories.Category_description;
            existingCategories.Category_image = updatedCategories.Category_image;
            


            await _context.SaveChangesAsync();

            return existingCategories; 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Category>> GetAllSearchAsync(string search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.Category_name.Contains(search));
                   
            }

            return await query.ToListAsync();
        }
    }
}
