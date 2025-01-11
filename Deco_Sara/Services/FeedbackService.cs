using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;

namespace Deco_Sara.Services 
{
    public class FeedbackService : IFeedbackService
    {
        private readonly Appdbcontext _context;

        public FeedbackService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }
        public async Task<Feedback?> UpdateAsync(int id, Feedback updatedFeedback)
        {
            // Find the employee in the database
            var existingFeedback = await _context.Feedbacks.FindAsync(id);
            if (existingFeedback == null)
            {
                return null; // Return null if the employee doesn't exist
            }

            // Update the employee fields
            existingFeedback.Rating = updatedFeedback.Rating;
           

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingFeedback; // Return the updated employee
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if ( feedback == null) return false;

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Feedback>> GetAllSearchAsync(string search)
        {
            var query = _context.Feedbacks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.FeedbackDescription.Contains(search));
                    
                   
            }

            return await query.ToListAsync();
        }


    }
}
