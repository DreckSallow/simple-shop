namespace backend.Core.Abstractions;

public interface IUserPasswordHasher
{
    string Hash(string password);
    bool Validate(string passwordHash, string password);
}
