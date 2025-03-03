using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IRoleservices
    {
        Task<List<Roll>> GetSubcatlist();
        Task<(IEnumerable<Roll> Roles, int TotalCount)> GetAllAsync(int page = 1, int pageSize = 10);
        Task<Roll> GetByIdAsync(int id);

        Task<Roll> AddAsync(Roll roles);

        Task<Roll?> UpdateAsync(int id, Roll roles);

        Task<bool> DeleteAsync(int id);




    }
}
