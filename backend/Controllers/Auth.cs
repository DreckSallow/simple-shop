using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;
using backend.Core.Abstractions;

namespace backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly ITokenService _tokenService;
    private readonly IUserPasswordHasher _passwordHasher;
    public AuthController(ApplicationContext context, ITokenService tokenService, IUserPasswordHasher passwordHasher)
    {
        this._context = context;
        this._tokenService = tokenService;
        this._passwordHasher = passwordHasher;
    }

    [HttpPost("/login")]
    public async Task<ActionResult> Login(UserAuthLogin userRequest)
    {
        var user = await this._context.Users.SingleOrDefaultAsync(u => u.Email == userRequest.Email);
        var valid = user is null ? false : this._passwordHasher.Validate(user.Password, userRequest.Password);
        if (user == null || !valid)
        {
            return BadRequest("Wrong credentials.");
        }
        var token = this._tokenService.GenerateToken(user!);
        return Ok(new
        {
            user = new UserResponse(user),
            token
        });
    }

    [HttpPost("/signup")]
    public async Task<ActionResult> Register(UserAuthCreate userRequest)
    {
        var user = await this._context.Users.SingleOrDefaultAsync(u => u.Email == userRequest.Email);
        if (user != null) { return BadRequest("Wrong credentials."); }
        var newUser = new User()
        {
            Email = userRequest.Email,
            Password = this._passwordHasher.Hash(userRequest.Password),
            FirstName = userRequest.FirstName,
            LastName = userRequest.LastName,
            Role = userRequest.Role
        };
        var token = this._tokenService.GenerateToken(newUser);
        await this._context.Users.AddAsync(newUser);
        await this._context.SaveChangesAsync();
        return Ok(new
        {
            user = new UserResponse(newUser),
            token
        });
    }
}
