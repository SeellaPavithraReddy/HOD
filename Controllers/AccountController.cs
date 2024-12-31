using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HODPoc.DBContext;
using HODPoc.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly HODContext _context;
    private readonly IConfiguration _configuration;

    public AccountController(HODContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    // Login method to authenticate users

    [HttpPost("login")]
    public IActionResult Login([FromBody] Login login)
    {
        var user = _context.logins.SingleOrDefault(u =>
            u.username == login.username && u.password == login.password
        );
        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.username),
            new Claim(ClaimTypes.Role, user.role),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
