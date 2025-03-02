using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;

namespace Deco_Sara.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class productController : ControllerBase
    {
        private readonly IProductservice _productService;

        public productController(IProductservice productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10)
        {
            var (products, totalcount) = await _productService.GetAllAsync(page, pagesize);
            var response = new
            {
                data = products.Select(v => new
                {
                    v.Product_Id,
                    v.Product_name,
                    v.Product_price,
                    v.Product_discount,
                    v.Product_image,




                    Subcategory = new
                    {
                        v.Subcategory.Subcategory_name,
                        v.Subcategory.Subcategory_image,
                        v.Subcategory.Subcategory_Id,
                        v.Subcategory.Subcategory_description


                    },
                    Category = new
                    {
                        v.Subcategory.Category.Category_name,
                        v.Subcategory.Category.Category_Id,
                        v.Subcategory.Category.Category_description,
                        v.Subcategory.Category.Category_image,
                    }

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
            var products = await _productService.GetByIdAsync(id);
            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var newproduct = await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = newproduct.Product_Id }, newproduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateproduct(int id, Product product)
        {
            var updatedproduct = await _productService.UpdateAsync(id, product);

            if (updatedproduct == null)
            {
                return NotFound();
            }

            return Ok(updatedproduct);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
