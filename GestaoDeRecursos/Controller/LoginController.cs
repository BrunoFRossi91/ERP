using AutoMapper;
using ERP.Data;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public LoginController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult VerifyUser([FromBody] UserLoginModel model)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (user.Password == model.Password)
            {
                return Ok("Valid credentials");
            }
            else
            {
                return Unauthorized("Incorrect password");
            }
        }
    }

    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
