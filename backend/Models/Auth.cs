using System.ComponentModel.DataAnnotations;

namespace backend.Models;


public enum UserRole
{
    Client = 0,
    Admin = 1
}

public class Auth
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [EnumDataType(typeof(UserRole))]
    public UserRole Role { get; set; }
    [Required]
    public int UserId { get; set; }
}
