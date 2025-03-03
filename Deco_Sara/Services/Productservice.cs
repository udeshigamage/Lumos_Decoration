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

        public async Task<List<Product>> Getcatlist(int subcatid)
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .Include(p => p.Subcategory)
                                 .Where(p => p.Subcategory_Id == subcatid) 
                                 .ToListAsync();
        }


        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .FirstOrDefaultAsync(p => p.Product_Id == id);
        }


        public async Task<Product> AddAsync(Product product)
        {

            product.Category = null;
            product.Subcategory = null;
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, Product updatedproduct)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) return null;

            existingProduct.Product_name = updatedproduct.Product_name;
            existingProduct.Product_price = updatedproduct.Product_price;
            existingProduct.Product_image = updatedproduct.Product_image;
            existingProduct.Product_discount = updatedproduct.Product_discount;

            // Fetch and assign Category & Subcategory
            existingProduct.Category = await _context.Categories.FindAsync(updatedproduct.Category_Id);
            existingProduct.Subcategory = await _context.Subcategories.FindAsync(updatedproduct.Subcategory_Id);

            existingProduct.Category_Id = updatedproduct.Category_Id;
            existingProduct.Subcategory_Id = updatedproduct.Subcategory_Id;

            await _context.SaveChangesAsync();
            return existingProduct;
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
