using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IProductservice
    {
        Task<(IEnumerable<Product> products, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> Getcatlist(int subcatid);
        Task<Product> AddAsync(Product product);

        Task<Product?> UpdateAsync(int id, Product updatedproduct);

        Task<bool> DeleteAsync(int id);

       
    }
}
