using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IEmployeeService
    {
        Task<(IEnumerable<Employee> Employees, int TotalCount)> GetAllAsync(int page = 1, int pageSize = 10);
        Task<Employee> GetByIdAsync(int id);

        Task<Employee> AddAsync(Employee employee);

        Task<Employee?> UpdateAsync(int id, Employee employee); 

        Task<bool> DeleteAsync(int id);

        

    }
}
