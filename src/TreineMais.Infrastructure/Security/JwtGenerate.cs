using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TreineMais.Application.DTO.Auth;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;

namespace TreineMais.Infrastructure.Security;

public class JwtGenerate : IJwtGenerate
{
    private readonly IConfiguration _configuration;

    public JwtGenerate(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwt(User request)
    {
        var issuer = _configuration["JWT:ISSUER"];
        var audience = _configuration["JWT:AUDIENCE"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:KEY"]!));

        var expiresSettings = _configuration["JWT:ACCESSTOKENEXPIRE"];
        double expireHoursInSeconds = double.TryParse(expiresSettings, out var result) ? result : 2;
        
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub, request.Id.ToString()),
           new Claim(ClaimTypes.Email, request.Login.Email.Value),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
           Subject = new ClaimsIdentity(claims),
           Expires = DateTime.UtcNow.AddSeconds(expireHoursInSeconds),
           Issuer = issuer,
           Audience = audience,
           SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}