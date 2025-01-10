using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order> GetByIdAsync(int id);

        Task<Order> AddAsync(Order order);

        Task<Order?> UpdateAsync(int id,Order order);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Order>> GetAllSearchAsync(string? search = null);


    }
}





