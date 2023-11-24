using Backend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserDataContext _context;
       

        public UserService(IConfiguration configuration ,UserDataContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        public User user = new User();
        public async Task<User> Register(UserDto req)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    var user = new User
                    {
                        Username = req.Username,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.PasswordHash)
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return user;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return null;
                }
            }
        }

        public string Login(UserDto req)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == req.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(req.PasswordHash, user.PasswordHash))
            {
                return null;
            }
            else
            {
                string token = CreateToken(user);
                return token;
            }
            
        }

        public string CreateToken(User user)
        {
           
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
    }

