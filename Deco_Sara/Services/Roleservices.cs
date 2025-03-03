using Deco_Sara.dbcontext__;
using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Roleservices:IRoleservices
    {
        private readonly Appdbcontext _context;

        public Roleservices(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<List<Roll>> GetSubcatlist()
        {

            return await _context.roll.ToListAsync();
        }

        public async Task<(IEnumerable<Roll> Roles, int TotalCount)> GetAllAsync(int page = 1, int pageSize = 10)
        {
            var totalCount = await _context.roll.CountAsync();

            var Role = await _context.roll
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (Role, totalCount);
        }


        public async Task<Roll> GetByIdAsync(int id)
        {
            return await _context.roll.FindAsync(id);
        }

        public async Task<Roll> AddAsync(Roll Role)
        {
            _context.roll.Add(Role);
            await _context.SaveChangesAsync();
            return Role;
        }
        public async Task<Roll?> UpdateAsync(int id, Roll updatedRole)
        {
            // Find the employee in the database
            var existingRole = await _context.roll.FindAsync(id);
            if (existingRole == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingRole.Roll_Name = updatedRole.Roll_Name;
           

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingRole; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Role = await _context.roll.FindAsync(id);
            if (Role == null) return false;

            _context.roll.Remove(Role);
            await _context.SaveChangesAsync();
            return true;
        }
       
    }
}
