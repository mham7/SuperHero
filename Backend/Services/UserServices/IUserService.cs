namespace Backend.Services.UserServices
{
    public interface IUserService
    {
        public Task<User> Register(UserDto req);   
        public string Login(UserDto req);
        public string CreateToken(User user);
    }
}
