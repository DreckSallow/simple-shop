using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly ITokenService _tokenService;
    public AuthController(ApplicationContext context, ITokenService tokenService)
    {
        this._context = context;
        this._tokenService = tokenService;
    }

    [HttpPost("/login")]
    public async Task<ActionResult> Login(UserAuthLogin userRequest)
    {
        var user = await this._context.Users.SingleOrDefaultAsync(u => u.Email == userRequest.Email);
        if (user == null) { return BadRequest("Wrong credentials."); }
        var token = this._tokenService.GenerateToken(user!);
        return Ok(new { user, token });
    }

    [HttpPost("/signup")]
    public async Task<ActionResult> SingUp(UserAuthCreate userRequest)
    {
        var user = await this._context.Users.SingleOrDefaultAsync(u => u.Email == userRequest.Email);
        if (user == null) { return BadRequest(new { type = "hasOne", msg = "User already registered." }); }
        var token = this._tokenService.GenerateToken(user!);
        return Ok(new { user, token });
    }
}
