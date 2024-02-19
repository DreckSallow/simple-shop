using System.Security.Cryptography;
using backend.Core.Abstractions;

namespace backend.Services;


public class UserPasswordHasher : IUserPasswordHasher
{
    private const int SaltSize = 128 / 8; //16
    private const int KeySize = 256 / 8; // 32
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName HashName = HashAlgorithmName.SHA256;
    private const char Delimiter = ';';
    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashName, KeySize);
        return String.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }
    public bool Validate(string passwordHash, string password)
    {
        var elements = passwordHash.Split(Delimiter);
        if (elements.Length < 2) return false;
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);
        var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashName, KeySize);
        return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }
}
