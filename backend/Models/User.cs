using System.ComponentModel.DataAnnotations;
namespace backend.Models;

public enum UserRole
{
    Client = 0,
    Admin = 1
}

public class User
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    [EnumDataType(typeof(UserRole))]
    public UserRole Role { get; set; }
    public DateTime creationDate { get; set; }

    public virtual Order Order { get; set; }
}
