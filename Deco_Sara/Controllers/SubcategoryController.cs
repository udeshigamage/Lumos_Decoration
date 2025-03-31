using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Deco_Sara.DTO;

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
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10,string searchterm="")
        {
            var (Subcategorys, totalcount) = await _SubcategoryService.GetAllAsync(page, pagesize,searchterm);


            var response = new
            {
                data =Subcategorys,
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
        [HttpGet("listallproducts_subcatgeory/{id}")]

        public async Task<IActionResult> Listallproducts_subcatgeory(int id)
        {
            var products = await _SubcategoryService.Listallproducts_subcatgeory(id);
            var response = new
            {
                data = products
            };
            return Ok(response);
        }

        [HttpGet("Subcategorylist")]

        public async Task<IActionResult> GetSubcategoryList()
        {
            var Subcategorys = await _SubcategoryService.GetSubcatlist();
            var response = new
            {
                data = Subcategorys
               
            };


            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSubcategoryDTO Subcategory)
        {
            var message = await _SubcategoryService.AddAsync(Subcategory);
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateproduct(int id, UpdatesubcategoryDTO Subcategory)
        {
            var Message = await _SubcategoryService.UpdateAsync(id, Subcategory);

           
            return Ok(Message);
        }


        [HttpGet("getallsubategorieslist/categories/{id}")]

        public async Task<IActionResult> getallsubcategorieslist(int id)
        {
            var subcategories = await _SubcategoryService.listallsubcategories(id);

            return Ok(subcategories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Message = await _SubcategoryService.DeleteAsync(id);
           
            return Ok( Message);
        }
    }
}
