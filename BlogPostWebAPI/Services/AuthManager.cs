using BlogPostWebAPI.Entities;
using BlogPostWebAPI.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogPostWebAPI.Services;

public class AuthManager(IConfiguration configuration) : IAuthManager
{
    private readonly IConfiguration _config = configuration.GetSection("Jwt");

    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Gender, user.Gender.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var issuer = _config["Issuer"];
        var audience = _config["Audience"];
        var secretKey = _config["SecretKey"];
        var expire = double.Parse(_config["Lifetime"]!);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
            expires: DateTime.Now.AddMinutes(expire),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
