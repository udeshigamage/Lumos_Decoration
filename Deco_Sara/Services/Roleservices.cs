﻿using Deco_Sara.dbcontext__;
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
        public async Task<List<Role>> GetSubcatlist()
        {

            return await _context.role.ToListAsync();
        }

        public async Task<(IEnumerable<Role> Roles, int TotalCount)> GetAllAsync(int page = 1, int pageSize = 10)
        {
            var totalCount = await _context.role.CountAsync();

            var Role = await _context.role
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (Role, totalCount);
        }


        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.role.FindAsync(id);
        }

        public async Task<Role> AddAsync(Role Role)
        {
            _context.role.Add(Role);
            await _context.SaveChangesAsync();
            return Role;
        }
        public async Task<Role?> UpdateAsync(int id, Role updatedRole)
        {
            // Find the employee in the database
            var existingRole = await _context.role.FindAsync(id);
            if (existingRole == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingRole.Role_Name = updatedRole.Role_Name;
           

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingRole; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Role = await _context.role.FindAsync(id);
            if (Role == null) return false;

            _context.role.Remove(Role);
            await _context.SaveChangesAsync();
            return true;
        }
       
    }
}
