using Deco_Sara.dbcontext__;
using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Productservice:IProductservice
    {
        private readonly Appdbcontext _context;

        public Productservice(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Product> products, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var query = _context.Products
                                 .Include(v => v.Category).Include(v=>v.Subcategory);
            var TotalCount = await query.CountAsync();
            var categorys = await query.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (categorys, TotalCount);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return await _context.Products
    .Include(p => p.Subcategory)    // Include the Subcategory data
        .ThenInclude(subcategory => subcategory.Category)  // Include the Category data within the Subcategory
    .FirstOrDefaultAsync(p => p.Product_Id == product.Product_Id);

        }
        public async Task<Product?> UpdateAsync(int id, Product updatedproduct)
        {

            var existingProducts = await _context.Products.FindAsync(id);
            if (existingProducts == null)
            {
                return null;
            }

            existingProducts.Product_name = updatedproduct.Product_name;
            existingProducts.Product_price = updatedproduct.Product_price;
            existingProducts.Product_image = updatedproduct.Product_image;
            existingProducts.Product_discount = updatedproduct.Product_discount;
            existingProducts.Category_Id = updatedproduct.Category_Id;
            existingProducts.Subcategory_Id = updatedproduct.Subcategory_Id;



            await _context.SaveChangesAsync();

            return existingProducts;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Products.FindAsync(id);
            if (category == null) return false;

            _context.Products.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Product>> GetAllSearchAsync(string search)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.Product_name.Contains(search));

            }

            return await query.ToListAsync();
        }
    }
}
