using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IFeedbackService
    {
        Task<(IEnumerable<Feedback> feedbacks, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10);
        Task<Feedback> GetByIdAsync(int id);

        Task<Feedback> AddAsync(Feedback feedback);

        Task<Feedback?> UpdateAsync(int id, Feedback feedback);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Feedback>> GetAllSearchAsync(string? search = null);

    }
}
