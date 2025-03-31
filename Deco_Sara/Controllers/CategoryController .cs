using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Authorization;
using Deco_Sara.DTO;

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
        
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10,string searchterm ="")
        {
            var (categorys, totalcount) = await _categoryservice.GetAllAsync(page, pagesize,searchterm);
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
            var Message = await _categoryservice.GetByIdAsync(id);
            
            return Ok(Message);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDTO category)
        {
            var message = await _categoryservice.AddAsync(category);
            return Ok(message);
            
        }
        [HttpGet("categorylist/{id}")]
        public async Task<IActionResult> GetSubcategoryList(int id)
        {
            var subcategorys = await _categoryservice.Listallsubcategories_catgeory(id);
            var response = new
            {
                subcategorys
            };

            return Ok(response);
        }

        [HttpGet("listallcategories/list")]
        public async Task<IActionResult> Getcategorylist()
        {
            var category = await _categoryservice.Listcatgeoryall();
            return Ok(category);

        }


        [HttpGet("category/categorylist")]

        public async Task<IActionResult> GetcategoryList()
        {
            var categorys = await _categoryservice.Getcatlist();
            var response = new
            {
                data = categorys

            };


            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecategory(int id, UpdateCategoryDTO category)
        {
            var message = await _categoryservice.UpdateAsync(id, category);

            

            return Ok(message);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _categoryservice.DeleteAsync(id);

            return Ok(message);
        }
    }
}
