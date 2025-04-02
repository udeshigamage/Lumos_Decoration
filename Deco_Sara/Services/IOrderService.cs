using Deco_Sara.DTO;
using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IOrderService

    {

        Task<List<Order>> GetAllOrdersForCustomerAsync(int customerId);

        
        Task<int> GetPendingOrdersCountAsync();
        Task<int> GetCompletedOrdersCountAsync();
        Task<int> GetAcceptedOrdersCountAsync();

        Task<int> GetProcessingOrdersCountAsync();

        Task<int> GettotalOrdersCountAsync();

        Task<int> GettodeliveredOrdersCountAsync();
        Task<int> GetconfirmedOrdersCountAsync();


        Task<(IEnumerable<Order> Order, int TotalCount)> GetAllOrdersAsync(int page = 1, int pageSize = 10);

        Task<Order> GetByIdAsync(int id);

        Task<int> AddAsync(int Customer_ID, List<OrderitemDTO> orderitems, CreateOrderDTO order);

        Task<Order?> UpdateAsync(int id,Order order);

        Task<bool> DeleteAsync(int id);

        Task<Message<string>> Updatestatusofallowance(int id);

        Task<Message<string>> Updatestatusofpayment(int id);

        Task<Message<string>> Updatestatusoforder(int id, string status);


        Task<List<OrderDTO>> GetOrderfinancialdetailsasyncbyid(int id);

        Task<Message<string>> AssignEmployee(int employeeId,int orderId);







    }
}





