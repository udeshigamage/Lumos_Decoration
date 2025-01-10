using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        

        Task<Order> AddAsync(Order order);

       
    }
}
