using BlazorApp_Login.Data;
using BlazorApp_Login.Dto_s;
using BlazorApp_Login.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Login.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AddDbContext _context;
    private readonly IUserRepository _usersRepository;
    public UserController(IUserRepository usersRepository, AddDbContext context)
    {
        _usersRepository = usersRepository;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Register(LoginDto loginDto)
    {
        var checkUser = await _context.User.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (checkUser == null)
        {
            return Ok(await _usersRepository.Register(loginDto));
        }
        return Ok();

    }
}
