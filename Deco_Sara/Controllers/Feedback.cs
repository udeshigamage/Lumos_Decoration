using Deco_Sara.Models;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Deco_Sara.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page=1,int pagesize=10)
        {
            var (feedbacks, totalcount) = await _feedbackService.GetAllAsync(page, pagesize);
            var response = new
            {
                data = feedbacks,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feedback = await _feedbackService.GetByIdAsync(id);
            if (feedback == null) return NotFound();
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Feedback feedback)
        {
            var newFeedback = await _feedbackService.AddAsync(feedback);
            return CreatedAtAction(nameof(GetById), new { id = newFeedback.FeedbackId }, newFeedback);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, Feedback feedback)
        {
            var updatedFeedback = await _feedbackService.UpdateAsync(id, feedback);

            if (updatedFeedback == null)
            {
                return NotFound();
            }

            return Ok(updatedFeedback);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _feedbackService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
