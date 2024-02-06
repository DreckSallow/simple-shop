using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using backend.Models;
namespace backend.Services;



public interface IAuth
{
    string generateToken(User user);
}


public class Auth : IAuth
{
    private string? SecretKey = null;
    private static readonly TimeSpan TokenTime = TimeSpan.FromDays(1);
    // private get Secret =()=>
    public Auth(string secretKey)
    {
        if (secretKey == null)
        {
            throw new ArgumentNullException(nameof(secretKey), "The secret key cannot be null");
        }
        this.SecretKey = secretKey;
    }
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(this.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public async Task<int?> ValidateToken(string? token)
    {
        if (token == null) return null;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(this.SecretKey);
        try
        {
            await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters()
            {
                //TODO: Check the parameters

            });
            return 1;
        }
        catch
        {
            return null;
        }
    }
}
