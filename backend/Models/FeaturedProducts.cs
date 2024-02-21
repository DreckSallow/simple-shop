using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models;


public class FeaturedProducts
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
}
