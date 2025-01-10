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
            existingEmployee.emp_Role = updatedEmployee.emp_Role;
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
                    e.emp_contact_no.Contains(search) ||
                    e.emp_Role.Contains(search));
            }

            return await query.ToListAsync();
        }


    }
}
