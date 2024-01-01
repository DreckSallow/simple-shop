using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using backend.Models;

namespace backend.Controllers;

public class ProductToCreate
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public Product ToProduct()
    {
        return new Product()
        {
            Name = this.Name,
            Price = this.Price,
            Description = this.Description,
            Brand = this.Brand,
            Discount = 0,
            Id = 0
        };
    }
}

[ApiController]
[Route("api/products/")]
public class ProductController : ControllerBase
{
    private readonly ApplicationContext _context;
    public ProductController(ApplicationContext context)
    {
        var p = new ProductToCreate();
        this._context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(ProductToCreate product)
    {
        if (product.Name.Length == 0 || product.Description.Length == 0 || product.Price < 0)
        {
            return BadRequest("The properties would have correct values");
        }

        var newProduct = product.ToProduct();
        var p = await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDetails), new { id = newProduct.Id }, newProduct);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDetails(int id)
    {
        var product = await Task.Run(() => _context.Products.SingleOrDefault((p) => p.Id == id));
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("")]
    public async Task<ActionResult> filterProducts([FromQuery] string? name, string? brand, int? maxPrice, int page)
    {
        if (page < 1) return BadRequest("Invalid page value.");
        const int pageSize = 30;

        var products = await _context.Products
            .Where(product =>
                product.Name.Contains(name ?? "") &&
                product.Brand.Contains(brand ?? "") &&
                (maxPrice.HasValue ? product.Price <= (maxPrice) : true)
            )
            .OrderBy(p => p.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(new
        {
            page,
            results = products,
            totalPages = Math.Ceiling(_context.Products.Count() / (decimal)pageSize)

        });
    }
}
