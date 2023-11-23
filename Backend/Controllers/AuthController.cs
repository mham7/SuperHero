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
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("Register")]

        public ActionResult<User> Register(UserDto reqDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(reqDto.PasswordHash);
            user.Username = reqDto.Username;
            user.PasswordHash = passwordHash;
            return Ok(user);
        }


        [HttpPost("Login")]

        public ActionResult<User> Login(UserDto reqDto)
        {
            if (user.Username!=reqDto.Username) {
                return BadRequest("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(reqDto.PasswordHash,user.PasswordHash)) {
                return BadRequest("Invalid Password");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user) {
            return null;
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Username)  };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:").Value!));

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:cred
                ) ;

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


    }
}
