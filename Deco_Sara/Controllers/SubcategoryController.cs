using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Deco_Sara.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryservice _SubcategoryService;

        public SubcategoryController(ISubcategoryservice SubcategoryService)
        {
            _SubcategoryService = SubcategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (Subcategorys, totalcount) = await _SubcategoryService.GetAllAsync(page, pagesize);


            var response = new
            {
                data =Subcategorys.Select(v => new
                {
                    v.Subcategory_name,
                    v.Subcategory_Id,
                    v.Subcategory_image,
                    v.Subcategory_description,
                    v.Category_Id,
                   

                    

                    Category = new
                    {
                        v.Category.Category_name,
                        v.Category.Category_Id,
                        v.Category.Category_description,
                        v.Category.Category_image,

                       
                    },
                    
                }),
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };
          

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Subcategorys = await _SubcategoryService.GetByIdAsync(id);
            if (Subcategorys == null) return NotFound();
            return Ok(Subcategorys);
        }
        [HttpGet("subcategory/category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var Subcategorys = await _SubcategoryService.GetSubcategoriesByCategoryIdAsync(categoryId);

            var response = new
            {
                data = Subcategorys.Select(v => new
                {
                    v.Subcategory_name,
                    v.Subcategory_Id,






                }),

            };


            return Ok(response);
        }

        [HttpGet("subcategory/category/list/{categoryId}")]
        public async Task<IActionResult> GetByategoryId(int categoryId)
        {
            var Subcategorys = await _SubcategoryService.GetSubcategoriesByCategoryIdAsync(categoryId);

            var response = new
            {
                data = Subcategorys.Select(v => new
                {
                    v.Subcategory_name,
                    v.Subcategory_Id,
                    v.Subcategory_image,
                    v.Subcategory_description






                }),

            };


            return Ok(response);
        }

        [HttpGet("Subcategorylist")]

        public async Task<IActionResult> GetSubcategoryList()
        {
            var Subcategorys = await _SubcategoryService.GetSubcatlist();
            var response = new
            {
                data = Subcategorys.Select(v => new
                {
                    v.Subcategory_name,
                    v.Subcategory_Id,
                    




                   
                }),
               
            };


            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Subcategory Subcategory)
        {
            var newSubcategory = await _SubcategoryService.AddAsync(Subcategory);
            return CreatedAtAction(nameof(GetById), new { id = newSubcategory.Subcategory_Id }, newSubcategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateproduct(int id, Subcategory Subcategory)
        {
            var updatedproduct = await _SubcategoryService.UpdateAsync(id, Subcategory);

            if (updatedproduct == null)
            {
                return NotFound();
            }

            return Ok(updatedproduct);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _SubcategoryService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
