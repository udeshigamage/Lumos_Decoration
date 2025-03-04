using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IRoleservices
    {
        Task<List<Role>> GetSubcatlist();
        Task<(IEnumerable<Role> Roles, int TotalCount)> GetAllAsync(int page = 1, int pageSize = 10);
        Task<Role> GetByIdAsync(int id);

        Task<Role> AddAsync(Role roles);

        Task<Role?> UpdateAsync(int id, Role roles);

        Task<bool> DeleteAsync(int id);




    }
}
