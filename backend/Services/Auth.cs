using System.IdentityModel.Tokens.Jwt;
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
    public string generateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(this.SecretKey);
        return "";
    }
}
