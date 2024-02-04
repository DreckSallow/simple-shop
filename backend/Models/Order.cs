using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}
