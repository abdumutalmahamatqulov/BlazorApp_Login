using BlazorApp_Login.Data;
using BlazorApp_Login.Dto_s;

namespace BlazorApp_Login.Interface;
public interface IUserRepository
{
    Task<User> Register(LoginDto loginDto);
    Task<User> Login(RegisterDto registerDto);
    Task<User> GetUserById(string email);
    Task UpdateUserAsync(User user);
}
