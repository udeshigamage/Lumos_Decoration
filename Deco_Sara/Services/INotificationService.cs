using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();

        Task<Notification> GetByIdAsync(int id);

        Task<Notification> AddAsync(Notification notification);

        Task<Notification?> UpdateAsync(int id,Notification notification);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Notification>> GetAllSearchAsync(string? search = null);
    }
}
