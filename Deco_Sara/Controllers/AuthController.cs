using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deco_Sara.Controllers
{
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
            var user = _context.Users.SingleOrDefault(c => c.Email == login.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.PasswordHash, user.PasswordHash))
            {
                return Unauthorized(new { message = "unauthorized" });
            }
            
            var token = _authService.Generatetoken(user);
            return Ok(token);
        }
    }
}
