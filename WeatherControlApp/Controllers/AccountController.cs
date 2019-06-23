using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WeatherControlApp.Dto;
using WeatherControlApp.Models;

[Route("api/Account/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly WeatherContext _context;
    private readonly IConfiguration _configuration;

    
    public AccountController(WeatherContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = _context.Users.AsQueryable().FirstOrDefault(s => s.Email == loginDto.Email && s.Password == loginDto.Password);
       
       if(user == null)
       {
           return Unauthorized();
       }
       
       var signingKey = Convert.FromBase64String(_configuration["Authentication:SigningSecret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(12),
                Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("userid", user.Id.ToString())
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return Ok(token);
    }


    [HttpPost]
    public IActionResult Register([FromBody] RegisterUserDto registerUser)
    {
        var user = _context.Users.AsQueryable().FirstOrDefault(s => s.Email == registerUser.Email);
        if(user != null)
        {
            return BadRequest("User with that email already existis");
        }


        user = new Users{
            Email = registerUser.Email,
            Firstname = registerUser.Firstname,
            Password = registerUser.Password
        };
        _context.Users.Add(user);

        _context.SaveChanges();

        return Ok();
    }

    public IActionResult GetAnonymous()
    {
        return Ok("Anonymous call");
    }

    [Authorize]
    public IActionResult GetAuthorized()
    {
        return Ok("Authorized call");
    }
}