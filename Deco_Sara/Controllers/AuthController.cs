using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly Appdbcontext _context;
        private readonly AuthService _authService;
        private readonly IConfiguration _configuration;
        
        public AuthController(Appdbcontext context, AuthService authService,IConfiguration configuration)
        {
            _context = context;
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task <IActionResult> Loginasync([FromBody] LoginDTO login)
        {
            var user_ = await _context.Users.FirstOrDefaultAsync(c => c.Email == login.Email); // Replace 'userEmail' with actual email

            if (user_ != null && !user_.isactive  )
            {
                return Unauthorized(new { message = "We have deactivated your email" });
            }

            var user = _context.Users.SingleOrDefault(c => c.Email == login.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.PasswordHash, user.PasswordHash))
            {
                return Unauthorized(new { message = "unauthorized" });
            }
            
            var token = _authService.Generatetoken(user);
            var users = _context.Users.Where(c => c.Email == login.Email).Select(c => new ViewUserDTO
            {
                Email = c.Email,
                Name = c.Name,
                Contact_no = c.Contact_no,
                Address = c.Address,
                Role = c.Role,
                User_ID =c.User_ID,
                userimage=c.userimage,
                Servicerole=c.Servicerole,

            }).ToListAsync();

            var response = new
            {
                data = users,
                token = token

            };
            
            return Ok(response);
        }
    }
}
