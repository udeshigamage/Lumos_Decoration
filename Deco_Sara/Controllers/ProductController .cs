using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;
using Deco_Sara.DTO;

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
        public async Task<IActionResult> GetAll(int page = 1, int pagesize = 10,string searchterm="")
        {
            var (products, totalcount) = await _productService.GetAllAsync(page, pagesize,searchterm);
            var response = new
            {
                data = products,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }
        [HttpGet("productalllist/list/{subcategory_id}")]

        public async Task<IActionResult> getallsubcaegories(int subcategory_id)

        {
            var products = await _productService.Listallproducts(subcategory_id);
            return Ok(products);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _productService.GetByIdAsync(id);
            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDTO product)
        {
            var message = await _productService.AddAsync(product);
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateproduct(int id,UpdateProductDTO product)
        {
            var message = await _productService.UpdateAsync(id, product);

            

            return Ok(message);
        }

        [HttpGet("productlist")]
        public async Task<IActionResult> GetproductList()
        {
            var products = await _productService.Getproductlist();
            var response = new
            {
                products
            };
            return Ok(response);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _productService.DeleteAsync(id);

            return Ok(message);
        }
    }
}
