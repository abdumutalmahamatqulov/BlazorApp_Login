using System;
using BlazorApp_Login.Data;
using BlazorApp_Login.Dto_s;
using BlazorApp_Login.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Login.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AddDbContext _context;

    public UserRepository(AddDbContext context) => _context = context;
    public async Task<User> Register(LoginDto loginDto)
    {
        var user = new User();
        user.Email = loginDto.Email;
        user.FullName = loginDto.FullName;
        user.Password = loginDto.Password;
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Login(RegisterDto registerDto)
    {
        var userFind =
            await _context.User.FirstOrDefaultAsync(u =>
                u.Email == registerDto.Email && u.Password == registerDto.Password);
        return userFind;
    }
    public async Task<User> GetUserById(string email)
    {
        var getUser = await _context.User.FirstOrDefaultAsync(e => e.Email == email);
        return getUser;
    }


    public async  Task UpdateUserAsync(User user)
    {
        var newItems = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email);
        newItems.Password = user.Password;

        _context.Entry(newItems).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
