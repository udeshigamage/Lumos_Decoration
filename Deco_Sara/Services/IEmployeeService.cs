using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);

        Task<Employee> AddAsync(Employee employee);

        Task<Employee?> UpdateAsync(int id, Employee employee); 

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Employee>> GetAllSearchAsync(string? search = null);

    }
}
