using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface ISubcategoryservice
    {
        Task<(IEnumerable<Subcategory> subcategorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);

        Task<List<Subcategory>> GetSubcatlist();
        

        Task<Subcategory> GetByIdAsync(int id);

        Task<Subcategory> AddAsync(Subcategory subcategory);

        Task<Subcategory?> UpdateAsync(int id, Subcategory updatedsubcategory);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Subcategory>> GetAllSearchAsync(string? search = null);
    }
}
