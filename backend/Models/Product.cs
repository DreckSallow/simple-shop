using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace backend.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public double Discount { get; set; }

    [JsonIgnore]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [JsonIgnore]
    public int BrandId { get; set; }

    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }
}
