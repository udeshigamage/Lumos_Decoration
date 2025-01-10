using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);

        Task<Customer> AddAsync(Customer customer);

        Task<Customer?> UpdateAsync(int id, Customer customer);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Customer>> GetAllSearchAsync(string? search = null);

    }
}
