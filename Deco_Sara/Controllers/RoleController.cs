using Deco_Sara.Models;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deco_Sara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleservices _roleservices;

        public RoleController(IRoleservices roleservices)
        {
            _roleservices = roleservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(int page = 1, int pageSize = 10)
        {
            var (roles, totalCount) = await _roleservices.GetAllAsync(page, pageSize);

            var response = new
            {
                data = roles,
                totalItems = totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                currentPage = page
            };

            return Ok(response);
        }
        [HttpGet("Rolelist")]

        public async Task<IActionResult> GetRoleList()
        {
            var roles = await _roleservices.GetSubcatlist();
            var response = new
            {
                data = roles.Select(v => new
                {
                    v.Role_ID,
                    v.Role_Name,
                }),

            };


            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var roles = await _roleservices.GetByIdAsync(id);
            if (roles == null) return NotFound();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Role roles)
        {
            var newRole = await _roleservices.AddAsync(roles);
            return CreatedAtAction(nameof(GetById), new { id = newRole.Role_ID }, newRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Role roles)
        {
            var updatedRoles = await _roleservices.UpdateAsync(id, roles);

            if (updatedRoles == null)
            {
                return NotFound();
            }

            return Ok(updatedRoles);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleservices.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
