using Backend.Services.UserServices;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly IUserService _userservice;

        public UserController( IUserService userService)
        {
           
            _userservice = userService;
        }
        [HttpPost("Register")]

        public async Task<ActionResult<User>> Register(UserDto reqDto)
        {
           var user = await _userservice.Register(reqDto);
            if (user == null) { return BadRequest("Incomplete credentials"); }
            else { return Ok(user); }
        }


        [HttpPost("Login")]

        public ActionResult<string> Login(UserDto reqDto)
        {
         

            string token = _userservice.Login(reqDto);
            if (token == null)
            {
                return BadRequest("Password or username is invalid");
            }
            else { return Ok(token); }
        }

      


    }
}
