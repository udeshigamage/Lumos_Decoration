using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IOrderService

    {

        Task<List<Order>> GetAllOrdersForCustomerAsync(int customerId);

        Task<int> GetPendingOrdersCountAsync(int customerId);
        Task<int> GetPendingOrdersCountAsync();
        Task<int> GetCompletedOrdersCountAsync();
        Task<int> GetNewOrdersCountAsync();

        Task<int> GetNewOrdersCountAsync(int customerId);

        Task<int> GetCompletedOrdersCountAsync(int customerId);


        Task<(IEnumerable<Order> Order, int TotalCount)> GetAllOrdersAsync(int page = 1, int pageSize = 10);

        Task<Order> GetByIdAsync(int id);

        Task<Order> AddAsync(Order order);

        Task<Order?> UpdateAsync(int id,Order order);

        Task<bool> DeleteAsync(int id);

       


    }
}





