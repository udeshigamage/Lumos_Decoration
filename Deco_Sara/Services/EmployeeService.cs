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

        public async Task<(IEnumerable<Employee> Employees, int TotalCount)> GetAllAsync(int page = 1, int pageSize = 10)
        {
            var query = _context.Employee.Include(e => e.role);
            var totalCount = await query.CountAsync();

            var employees = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (employees, totalCount);
        }


        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employees)
        {
            employees.role = null;
            _context.Employee.Add(employees);
            await _context.SaveChangesAsync();
            return employees;
        }
        public async Task<Employee?> UpdateAsync(int id, Employee updatedEmployee)
        {
            // Find the employee in the database
            var existingEmployee = await _context.Employee.FindAsync(id);
            if (existingEmployee == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingEmployee.email = updatedEmployee.email;
            existingEmployee.emp_address = updatedEmployee.emp_address;
            existingEmployee.emp_Name = updatedEmployee.emp_Name;
           existingEmployee.emp_image = updatedEmployee.emp_image;
            existingEmployee.Role_ID = updatedEmployee.Role_ID;
            existingEmployee.emp_contact_no = updatedEmployee.emp_contact_no;
            existingEmployee.emp_allowance = updatedEmployee.emp_allowance;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingEmployee; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employees = await _context.Employee.FindAsync(id);
            if (employees == null) return false;

            _context.Employee.Remove(employees);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Employee>> GetAllSearchAsync(string search)
        {
            var query = _context.Employee.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.emp_Name.Contains(search) ||
                    e.emp_contact_no.Contains(search));
                  
            }

            return await query.ToListAsync();
        }


    }
}
