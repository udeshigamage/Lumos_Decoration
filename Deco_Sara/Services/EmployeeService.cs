using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;

namespace Deco_Sara.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Appdbcontext _context;

        public EmployeeService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
