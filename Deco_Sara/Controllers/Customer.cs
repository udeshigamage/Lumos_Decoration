using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;

namespace Deco_Sara.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page=1,int pagesize=10)
        {
            var (customers,totalcount) = await _customerService.GetAllAsync(page,pagesize);
            var response = new
            {
                data = customers,
                totalItems = totalcount,
                totalPages = (int)Math.Ceiling((double)totalcount / pagesize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await _customerService.GetByIdAsync(id);
            if (customers == null) return NotFound();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            var newCustomer = await _customerService.AddAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = newCustomer.Customer_ID }, newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Customer customer)
        {
            var updatedEmployee = await _customerService.UpdateAsync(id, customer);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
