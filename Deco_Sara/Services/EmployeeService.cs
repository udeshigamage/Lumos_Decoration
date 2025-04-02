using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;
using System.Drawing.Printing;

namespace Deco_Sara.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Appdbcontext _context;

        public EmployeeService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ViewUserDTO> Employees, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10, string searchterm = "")
        {
            try
            {



                var query = _context.Users
     .Where(c => c.RoleName == "Employee")
     .AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchterm))
                {
                    query = query.Where(c => c.Name.Contains(searchterm)|| c.Address.Contains(searchterm) || c.Servicerole.Contains(searchterm));
                }
                var totalcount = await query.CountAsync();
                var viewCustomers_ = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewUserDTO
                {
                    Name = c.Name,
                    RoleName = c.RoleName,
                    Address = c.Address,
                    NIC = c.NIC,
                    Contact_no = c.Contact_no,
                    Role = c.Role,
                    Servicerole = c.Servicerole,
                    User_ID = c.User_ID,
                    userimage = c.userimage,
                    Email = c.Email,
                    isactive = c.isactive
                   





,
                }).ToListAsync();

                return (viewCustomers_, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
        }

        public async Task<(List<Order>, int totalcount)> GetordersbyEmplyeeid(int emploeeid, int page = 1, int pagesize = 5)
        {
            try
            {
                var query = _context.Order.
                    Include(c => c.Employee).Where(c => c.Employee_ID == emploeeid && c.Order_status !="denied" && c.Order_status!="pending" && c.Order_allowance_status ==true).AsQueryable();
                var orders = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new Order
                {
                    Order_ID = c.Order_ID,
                    Order_deadlinedate = c.Order_deadlinedate,
                    Order_allowance = c.Order_allowance,
                    Order_allowance_status = c.Order_allowance_status,
                    Order_date = c.Order_date,
                    Order_payment_status = c.Order_payment_status,
                    Order_status = c.Order_status,
                    Order_description = c.Order_description,
                    TotalCost = c.TotalCost,
                    Customer_ID = c.Customer_ID,
                    Employee_ID = c.Employee_ID,
                    Orderitems = c.Orderitems,
                    Customer = c.Customer,
                    Employee = c.Employee
                }).ToListAsync();
                var totalcount = await query.CountAsync();

                return (orders, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
        }

        public async Task<int> GetCountconfirmedordersbyEmplyeeid(int emploeeid)
        {
            try
            {
                var count = await _context.Order.
                    Include(c => c.Employee).Where(c => c.Employee_ID == emploeeid && c.Order_status == "confirmed" ).CountAsync();
               
               

                return (count);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
        }


        public async Task<int> GetCountprocessingdordersbyEmplyeeid(int emploeeid)
        {
            try
            {
                var count = await _context.Order.
                    Include(c => c.Employee).Where(c => c.Employee_ID == emploeeid && c.Order_status == "processing").CountAsync();



                return (count);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
        }



        public async Task<List<ListuserDTO>> GetAllEmployeelistAsync()
        {
            try
            {
                var employeelist = await _context.Users.Where(c => c.RoleName == "Employee").Select(c => new ListuserDTO
                {
                    Name = c.Name,
                    User_ID = c.User_ID,

                }).ToListAsync();

                return employeelist;


            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
        }

        public async Task<Message<string>> UpdateAsync(int id, UpdateUserDTO updatedEmployee)
        {
            // Find the employee in the database
            var existingEmployee = await _context.Users
                .FirstOrDefaultAsync(c => c.RoleName == "Employee" && c.User_ID == id);

            if (existingEmployee == null)
            {
                return new Message<string>
                {
                    Result = "error",
                    Status = "error",
                    Text = "Employee not found"
                };
            }

            // Update the employee fields
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Address = updatedEmployee.Address;
            existingEmployee.userimage = updatedEmployee.userimage;
            existingEmployee.PasswordHash = updatedEmployee.PasswordHash;
            existingEmployee.NIC = updatedEmployee.NIC;
            existingEmployee.Servicerole = updatedEmployee.Servicerole;

            existingEmployee.Contact_no = updatedEmployee.Contact_no;
            existingEmployee.LastUpdatedTime = DateTime.Now;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return new Message<string>
            {
                Result = "success",
                Status = "success",
                Text = "Successfully updated"
            };
        }


        public async Task<Message<string>> DeactivateAsync(int id)
        {
            var employees = await _context.Users
                .FirstOrDefaultAsync(c => c.RoleName == "Employee" && c.User_ID == id);
            if (employees == null) return new Message<string>
            {
                Result = "error",
                Status = "error",

            };

            employees.isactive = false;


            await _context.SaveChangesAsync();
            return new Message<string>
            {
                Result = "success",
                Status = "success",


            };



        }

        public async Task<Message<string>> ActiveAsync(int id)
        {
            var employees = await _context.Users
                .FirstOrDefaultAsync(c => c.RoleName == "Employee" && c.User_ID == id);
            if (employees == null) return new Message<string>
            {
                Result = "error",
                Status = "error",

            };

            employees.isactive = true;


            await _context.SaveChangesAsync();
            return new Message<string>
            {
                Result = "success",
                Status = "success",


            };



        }
    }
    }
