using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;
using Deco_Sara.DTO;

namespace Deco_Sara.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("EmployeeList")]

        public async Task<IActionResult> GetAllEmployeelists()
        {

           var employees = await _employeeService.GetAllEmployeelistAsync();
            return Ok(employees);
        }
        [HttpGet("EmployeeOrders/{id}")]

        public async Task<IActionResult> GetEmployeeOrders(int id, int page = 1, int pageSize = 5)
        {
            var orders = await _employeeService.GetordersbyEmplyeeid(id, page, pageSize);
            return Ok(orders);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees(int page = 1, int pageSize = 10,string searchterm ="")
        {
            var (employees, totalCount) = await _employeeService.GetAllAsync(page, pageSize,searchterm);

            var response = new
            {
                data = employees,
                totalItems = totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                currentPage = page
            };

            return Ok(response);
        }


        [HttpPut("Deactivate/{id}")]
        public async Task<IActionResult> Deactivateasync(int id)
        {
            var message = await _employeeService.DeactivateAsync(id);
            return Ok(message);
        }
        [HttpPut("Activateuser/{id}")]
        public async Task<IActionResult> Activateasync(int id)
        {
            var message = await _employeeService.ActiveAsync(id);
            return Ok(message);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateUserDTO employee)
        {
            var message = await _employeeService.UpdateAsync(id, employee);

            if (message == null)
            {
                return NotFound(); 
            }

            return Ok(message); 
        }




        
    }
}
