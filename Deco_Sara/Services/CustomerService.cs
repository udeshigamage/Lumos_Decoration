using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;

namespace Deco_Sara.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Appdbcontext _context;

        public CustomerService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ViewUserDTO>customers,int TotalCount)> GetAllAsync(int page=1,int pagesize=10,string searchterm="")
        {
            try
            {
               
                
               
                var query = _context.Users
     .Where(c => c.RoleName == "Customer")
     .AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchterm))
                {
                    query = query.Where(c => c.Name.Contains(searchterm) );
                }
                var totalcount = await query.CountAsync();
                var viewCustomers_ = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewUserDTO
                {
                  Name= c.Name,
                  RoleName= c.RoleName,
                  Role= c.Role,
                  Address= c.Address,
                  Email=c.Email,
                  Servicerole=c.Servicerole,
                  NIC=c.NIC,
                  Contact_no=c.Contact_no,
                  User_ID =c.User_ID
                  

,
                }).ToListAsync();

                return (viewCustomers_, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
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
