using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
}
