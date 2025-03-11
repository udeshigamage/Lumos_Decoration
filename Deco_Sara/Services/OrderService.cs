using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;


namespace Deco_Sara.Services
{
    public class OrderService:IOrderService
    {
        
        private readonly Appdbcontext _context;

        public OrderService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Order> Order, int TotalCount)> GetAllOrdersAsync(int page = 1, int pageSize = 10)
        {
            var query =  _context.Order.Include(order => order.Orderitems).ThenInclude(Orderitem => Orderitem.Product).Include(order => order.Customer);
            var totalCount = await query.CountAsync();

            var Order = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
                
            return (Order, totalCount);
        }

        


        


        public async Task<List<Order>> GetAllOrdersForCustomerAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId)
                .ToListAsync();
        }

        public async Task<int> GetPendingOrdersCountAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId && order.Order_status == "pending")
                .CountAsync();
        }
        public async Task<int> GetNewOrdersCountAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId && order.Order_status == "To Accept")
                .CountAsync();
        }
        public async Task<int> GetNewOrdersCountAsync()
        {
            return await _context.Order
                .Where(order =>  order.Order_status == "To Accept")
                .CountAsync();
        }
        public async Task<int> GetCompletedOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.Order_status == "Completed")
                .CountAsync();
        }
        public async Task<int> GetPendingOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.Order_status == "pending")
                .CountAsync();
        }
        public async Task<int> GetCompletedOrdersCountAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId && order.Order_status == "Completed")
                .CountAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Order.FindAsync(id);
        }
        public async Task<int> AddAsync(int Customer_ID, List<OrderitemDTO> orderitems, OrderDTO order)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
               
                var orders = new Order
                {
                    Customer_ID = Customer_ID,
                    Order_date = DateTime.Now,
                    Order_allowance = order.Order_allowance,
                    Order_status = order.Order_status,
                    Order_description = order.Order_description,
                    Order_allowance_status = order.Order_allowance_status,
                    Order_payment_status = order.Order_payment_status,
                    TotalCost = order.TotalCost
                };

                
                _context.Order.Add(orders);
                await _context.SaveChangesAsync(); 
               
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

