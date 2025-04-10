using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;

namespace Deco_Sara.Services 
{
    public class FeedbackService : IFeedbackService
    {
        private readonly Appdbcontext _context;

        public FeedbackService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Feedback> feedbacks, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10)
        {
            var TotalCount = await _context.Feedbacks.CountAsync();
            var feedbacks = await _context.Feedbacks.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return (feedbacks, TotalCount);
        }

        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task<Message<string>> AddAsync(CreateFeedbackDTO feedback)
        {
            try
            {
                var Feedback = new Feedback
                {
                    Rating = feedback.Rating,
                    FeedbackDescription = feedback.FeedbackDescription,
                    FeedbackDate = DateTime.Now,
                    IsResolved = false,
                    Customer_ID = feedback.Customer_ID,
                    filepath = feedback.fileurl,


                };
                await _context.Feedbacks.AddAsync(Feedback);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Text = "Feedback added successfully",
                    Status = "S",
                    Code = "200",
                    Result = null
                };


            }
            catch(Exception ex)
            {
                return new Message<string>
                {
                   Text = ex.Message,
                   Status = "E",
                   Code = "500",
                   Result = null
                };
            }
           
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
