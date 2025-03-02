using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface ICategoryservice
    {
        Task<(IEnumerable<Category> categorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> Getcatlist();
        Task<Category> AddAsync(Category category);

        Task<Category?> UpdateAsync(int id, Category category);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Category>> GetAllSearchAsync(string? search = null);
    }
}
