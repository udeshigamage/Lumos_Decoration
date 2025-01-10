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

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Order.ToListAsync();
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
        public async Task<IEnumerable<Order>> GetAllSearchAsync(string search)
        {
            var query = _context.Order.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.status.Contains(search) ||
                   
                    e.location.Contains(search));
            }

            return await query.ToListAsync();
        }


    }
}

