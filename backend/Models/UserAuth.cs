namespace backend.Models;

public class UserAuthLogin
{
    public required string Email { get; set; }
    public required string Password { get; set; }

}

public class UserAuthCreate
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public UserRole Role { get; set; }

}
