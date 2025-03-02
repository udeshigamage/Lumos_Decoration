using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;

namespace Deco_Sara.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryservice _categoryservice;

        public CategoryController(ICategoryservice categoryservice)
        {
            _categoryservice = categoryservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (categorys, totalcount) = await _categoryservice.GetAllAsync(page, pagesize);
            var response = new
            {
                data = categorys,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categorys = await _categoryservice.GetByIdAsync(id);
            if (categorys == null) return NotFound();
            return Ok(categorys);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            var newcategory = await _categoryservice.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = newcategory.Category_Id }, newcategory);
        }
        [HttpGet("categorylist")]

        public async Task<IActionResult> GetSubcategoryList()
        {
            var categorys = await _categoryservice.Getcatlist();
            var response = new
            {
                data = categorys.Select(v => new
                {
                    v.Category_name,
                    v.Category_Id






                }),

            };


            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecategory(int id, Category category)
        {
            var updatedcategory = await _categoryservice.UpdateAsync(id, category);

            if (updatedcategory == null)
            {
                return NotFound();
            }

            return Ok(updatedcategory);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryservice.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
