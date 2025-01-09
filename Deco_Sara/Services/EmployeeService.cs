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
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employees)
        {
            _context.Employee.Add(employees);
            await _context.SaveChangesAsync();
            return employees;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var employees = await _context.Employee.FindAsync(id);
            if (employees == null) return false;

            _context.Employee.Remove(employees);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
