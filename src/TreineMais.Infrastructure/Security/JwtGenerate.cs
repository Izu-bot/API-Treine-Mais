using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TreineMais.Application.DTO.Auth;
using TreineMais.Application.Security;
using TreineMais.Domain.Abstractions;

namespace TreineMais.Infrastructure.Security;

public class JwtGenerate : IJwtGenerate
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;

    public JwtGenerate(IUserRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public string GenerateJwt(AuthRequest request)
    {
        var user = _repository.GetByEmailAsync(request.Email);

        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
           new Claim(ClaimTypes.Email, request.Email),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
           Subject = new ClaimsIdentity(claims),
           Expires = DateTime.Now.AddHours(2),
           Issuer = issuer,
           Audience = audience,
           SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}