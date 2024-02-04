using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Models;


public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = null!;
}
