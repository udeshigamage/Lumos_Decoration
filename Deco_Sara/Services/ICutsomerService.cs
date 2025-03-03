using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface ICustomerService
    {
        Task<(IEnumerable<Customer> customers,int TotalCount)> GetAllAsync(int page=1,int pagesize=10);
        Task<Customer> GetByIdAsync(int id);

        Task<Customer> AddAsync(Customer customer);

        Task<Customer?> UpdateAsync(int id, Customer customer);

        Task<bool> DeleteAsync(int id);

       

    }
}
