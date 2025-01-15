using Microsoft.AspNetCore.Mvc;
using Deco_Sara.Models;
using Deco_Sara.Services;

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

        [HttpGet]
        public async Task<IActionResult> GetEmployees(int page = 1, int pageSize = 10)
        {
            var (employees, totalCount) = await _employeeService.GetAllAsync(page, pageSize);

            var response = new
            {
                data = employees,
                totalItems = totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                currentPage = page
            };

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var newEmployee = await _employeeService.AddAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = newEmployee.Emp_ID }, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = await _employeeService.UpdateAsync(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound(); 
            }

            return Ok(updatedEmployee); 
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
