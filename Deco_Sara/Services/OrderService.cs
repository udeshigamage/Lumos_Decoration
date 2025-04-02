using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;


namespace Deco_Sara.Services
{
    public class OrderService:IOrderService
    {
        
        private readonly Appdbcontext _context;

        public OrderService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<Message<string>> AssignEmployee( int employeeId,int orderId)
        {
            try
            {
                var order = await _context.Order.FindAsync(orderId);
                if (order == null)
                {
                    return new Message<string> { Text = "Order not found", Status = "F" };
                }

                var employee = await _context.Users.FindAsync(employeeId);
                if (employee == null)
                {
                    return new Message<string> { Text = "Employee not found", Status = "F" };
                }

                order.Employee_ID = employeeId;
                await _context.SaveChangesAsync();

                return new Message<string> { Text = "Employee assigned to order", Status = "S" };

            }
            catch (Exception ex)
            {
                return new Message<string> { Text = "Error", Status = "F" };
            }
        }

        public async Task<(IEnumerable<Order> Order, int TotalCount)> GetAllOrdersAsync(int page = 1, int pageSize = 10)
        {
            var query =  _context.Order.Include(order => order.Orderitems).ThenInclude(Orderitem => Orderitem.Product).Include(order => order.Customer).Include(order =>order.Employee);
            var totalCount = await query.CountAsync();

            var Order = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
                
            return (Order, totalCount);
        }

        public async Task<Message<string>> Updatestatusofallowance(int id)
        {
            try
            {
                var order = await _context.Order.FindAsync(id);
                if (order == null)
                {
                    return new Message<string> { Text = "Order not found", Status = "F" };
                }

                order.Order_allowance_status = true;
                await _context.SaveChangesAsync();

                return new Message<string> { Text = "Order allowance status updated", Status = "S" };

            }
            catch (Exception)
            {
                return new Message<string> { Text = "Error", Status = "S" };
            }
        }

        public async Task<Message<string>> Updatestatusofpayment(int id)
        {
            try
            {
                var order = await _context.Order.FindAsync(id);
                if (order == null)
                {
                    return new Message<string> { Text = "Order not found", Status = "F" };
                }

                order.Order_payment_status = true;
                await _context.SaveChangesAsync();

                return new Message<string> { Text = "Order payment status updated", Status = "S" };

            }
            catch (Exception)
            {
                return new Message<string> { Text = "Error", Status = "S" };
            }
        
        }

        public async Task<Message<string>> Updatestatusoforder(int id, string status) { 
        
            try
            {
                var order = await _context.Order.FindAsync(id);
                if (order == null)
                {
                    return new Message<string> { Text = "Order not found", Status = "F" };
                }

                order.Order_status = status;
                await _context.SaveChangesAsync();

                return new Message<string> { Text = "Order status updated", Status = "S" };

            }
            catch (Exception)
            {
                return new Message<string> { Text = "Error", Status = "S" };
            }
        }

        public async Task<List<OrderDTO>> GetOrderfinancialdetailsasyncbyid(int id)
        {
            try
            {
                var order = await _context.Order.FindAsync(id);
                if (order == null)
                {
                    return null;
                }

                var orderitems = await _context.OrderItems.Where(orderitem => orderitem.Order_ID == id).ToListAsync();
                var orderDTO = new List<OrderDTO>();

                foreach (var item in orderitems)
                {
                    var product = await _context.Products.FindAsync(item.Product_ID);
                    if (product == null)
                    {
                        throw new Exception($"Product {item.Product_ID} not found.");
                    }

                    orderDTO.Add(new OrderDTO
                    {
                        Order_ID = order.Order_ID,
                        Order_description = order.Order_description,
                        Order_deadlinedate = order.Order_deadlinedate,
                        Customer_ID = order.Customer_ID,
                        Order_allowance = order.Order_allowance,
                        Order_payment_status = order.Order_payment_status,
                        Order_allowance_status = order.Order_allowance_status,
                        Order_status = order.Order_status,
                        TotalCost = order.TotalCost
                    });
                }

                return orderDTO;

            }
            catch (Exception)
            {
                throw;
            }

        }








        public async Task<List<Order>> GetAllOrdersForCustomerAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId)
                .ToListAsync();
        }

        public async Task<int> GetPendingOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.Order_status == "pending")
                .CountAsync();
        }
        public async Task<int> GetAcceptedOrdersCountAsync()
        {
            return await _context.Order
                .Where(order =>  order.Order_status == "accepted")
                .CountAsync();
        }
        public async Task<int> GetProcessingOrdersCountAsync()
        {
            return await _context.Order
                .Where(order =>  order.Order_status == "processing")
                .CountAsync();
        }
        public async Task<int> GetCompletedOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.Order_status == "completed")
                .CountAsync();
        }
        public async Task<int> GettodeliveredOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.Order_status == "todelivered")
                .CountAsync();
        }
        public async Task<int> GetconfirmedOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.Order_status == "confirmed")
                .CountAsync();
        }

        public async Task<int> GettotalOrdersCountAsync()
        {
            return await _context.Order
                
                .CountAsync();
        }


        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Order.FindAsync(id);
        }
        public async Task<int> AddAsync(int Customer_ID, List<OrderitemDTO> orderitems, CreateOrderDTO order)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Creating the order object
                var orders = new Order
                {
                    Customer_ID = order.Customer_ID,
                    Order_date = DateTime.Now,
                    Order_description = order.Order_description,
                    Order_deadlinedate = order.Order_deadlinedate,
                    Order_allowance = order.Order_allowance,
                    Order_status = order.Order_status,
                    Order_allowance_status = order.Order_allowance_status,
                    Order_payment_status = order.Order_payment_status,
                    TotalCost = order.TotalCost
                };

                

                // Adding the order to the context
                _context.Order.Add(orders);
                await _context.SaveChangesAsync();

                // Handling Orderitems
                foreach (var item in orderitems)
                {
                    var product = await _context.Products.FindAsync(item.Product_ID);
                    if (product == null)
                    {
                        throw new Exception($"Product {item.Product_ID} not found.");
                    }

                    var orderItem = new Orderitem
                    {
                        Order_ID = orders.Order_ID,
                        Product_ID = item.Product_ID,
                        quantity = item.quantity
                    };

                    _context.OrderItems.Add(orderItem);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return orders.Order_ID;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }



        public async Task<Order?> UpdateAsync(int id, Order updatedOrder)
        {
            
            var existingOrder = await _context.Order.FindAsync(id);
            if (existingOrder == null)
            {
                return null; 
            }

            
            existingOrder.Order_allowance_status = updatedOrder.Order_allowance_status;
            existingOrder.Order_payment_status= updatedOrder.Order_payment_status;
            existingOrder.TotalCost = updatedOrder.TotalCost;           

            
            await _context.SaveChangesAsync();

            return existingOrder; 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null) return false;

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
        


    }
}

