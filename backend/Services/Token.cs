using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using backend.Models;
namespace backend.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}


public class TokenService : ITokenService
{
    private string? SecretKey = null;
    private string? Issuer = null;
    private string? Audience = null;
    private static readonly TimeSpan TokenTime = TimeSpan.FromDays(1);
    public TokenService(ConfigurationManager config)
    {
        var secretKey = config["JwtSettings:Key"];
        if (secretKey == null)
        {
            throw new ArgumentNullException(nameof(secretKey), "The secret key cannot be null");
        }
        this.SecretKey = secretKey;
        this.Issuer = config["JwtSettings:Issuer"];
        this.Audience = config["JwtSettings:Audiencie"];
    }
    private Claim[] ClaimsList(User user)
    {
        return new[] {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
         };
    }
    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var token = new JwtSecurityToken(this.Issuer, this.Audience, this.ClaimsList(user), expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public int? ValidateToken(string? token)
    {
        if (token == null) return null;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(this.SecretKey!);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            return int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
        }
        catch
        {
            return null;
        }
    }
}
