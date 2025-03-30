using Deco_Sara.DTO;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deco_Sara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuserservice _userservice;

        public UserController(Iuserservice userservice)
        {
            _userservice = userservice;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetEmployees(int page = 1, int pageSize = 10,string searchterm="")
        {
            var (users, totalCount) = await _userservice.Getallusersasync(page, pageSize,searchterm);

            var response = new
            {
                data = users,
                totalItems = totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                currentPage = page
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _userservice.Getuserbyidasync(id);
            if (users == null) return NotFound();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO user)
        {
            var message=await _userservice.Createuserasync(user);
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDTO user)
        {
            var message = await _userservice.Updateuserasync(user,id);
            
            

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _userservice.Deleteuserasync(id);
           

            return Ok(message);
        }
        
    }
}
