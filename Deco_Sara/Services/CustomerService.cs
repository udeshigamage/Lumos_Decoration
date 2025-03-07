using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;

namespace Deco_Sara.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Appdbcontext _context;

        public CustomerService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Customer>customers,int TotalCount)> GetAllAsync(int page=1,int pagesize=10)
        {
            var TotalCount = await _context.Customer.CountAsync();
            var customers = await _context.Customer.Skip((page-1)*pagesize).Take(pagesize).ToListAsync();
            return (customers, TotalCount);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer?> UpdateAsync(int id, Customer updatedCustomer)
        {
            // Find the employee in the database
            var existingCustomer = await _context.Customer.FindAsync(id);
            if (existingCustomer == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingCustomer.Customer_email = updatedCustomer.Customer_email;
            existingCustomer.Customer_name = updatedCustomer.Customer_name;
            existingCustomer.Customer_address = updatedCustomer.Customer_address;
            existingCustomer.Customer_contact_no = updatedCustomer.Customer_contact_no;



            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingCustomer; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null) return false;

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
       


    }
}
