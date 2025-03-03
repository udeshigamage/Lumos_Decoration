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
            var totalCount = await _context.Order.CountAsync();

            var Order = await _context.Order
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (Order, totalCount);
        }

        


        // Query to get the count of pending orders for the specified customer


        public async Task<List<Order>> GetAllOrdersForCustomerAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId)
                .ToListAsync();
        }

        public async Task<int> GetPendingOrdersCountAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId && order.status == "pending")
                .CountAsync();
        }
        public async Task<int> GetNewOrdersCountAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId && order.status == "To Accept")
                .CountAsync();
        }
        public async Task<int> GetNewOrdersCountAsync()
        {
            return await _context.Order
                .Where(order =>  order.status == "To Accept")
                .CountAsync();
        }
        public async Task<int> GetCompletedOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.status == "Completed")
                .CountAsync();
        }
        public async Task<int> GetPendingOrdersCountAsync()
        {
            return await _context.Order
                .Where(order => order.status == "pending")
                .CountAsync();
        }
        public async Task<int> GetCompletedOrdersCountAsync(int customerId)
        {
            return await _context.Order
                .Where(order => order.Customer_ID == customerId && order.status == "Completed")
                .CountAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Order.FindAsync(id);
        }

        public async Task<Order> AddAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order?> UpdateAsync(int id, Order updatedOrder)
        {
            // Find the employee in the database
            var existingOrder = await _context.Order.FindAsync(id);
            if (existingOrder == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingOrder.status = updatedOrder.status;
            existingOrder.deadlinedate= updatedOrder.deadlinedate;
            existingOrder.TotalCost = updatedOrder.TotalCost;           

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingOrder; // Return the updated employee
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

