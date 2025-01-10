using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IAllowancesServices
    {
        Task<IEnumerable<Allowance>> GetAllAllowanceAsync();

        Task<Allowance> GetByIdAsync(int id);

        Task<Allowance> AddAsync(Allowance allowance);

        Task<Allowance?> UpdateAsync(int id, Allowance allowance);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Allowance>> GetAllSearchAsync(string? search = null);
    }
}
