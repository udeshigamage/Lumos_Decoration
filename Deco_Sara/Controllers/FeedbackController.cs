using Deco_Sara.DTO;
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
        private readonly AwsS3Service _awsS3Service;

        public FeedbackController(IFeedbackService feedbackService,AwsS3Service awsS3Service)
        {
            _feedbackService = feedbackService;
            _awsS3Service = awsS3Service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
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

        [HttpPost("feedback")]
        public async Task<IActionResult> Add([FromForm] CreateFeedbackDTO feedback,  IFormFile file)
        {
            // Check if the file is present and not empty
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Extract file name and extension
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);

            // Generate a unique file name using Guid
            var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

            // Open the file stream for uploading
            using var stream = file.OpenReadStream();

            // Upload the file to AWS S3
            var s3FileUrl = await _awsS3Service.UploadFileAsync(stream, uniqueFileName);

            // Check if the file was uploaded successfully to S3
            if (s3FileUrl == null)
                return StatusCode(500, "Failed to upload the file.");

            // Attach the S3 file URL to the feedback DTO (assuming CreateFeedbackDTO has a FileUrl property)
            feedback.fileurl = s3FileUrl; // Add this property to your DTO if it doesn't exist

            // Add the feedback asynchronously
            var message = await _feedbackService.AddAsync(feedback);

            // Return a response with the result
            return Ok(message);
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
