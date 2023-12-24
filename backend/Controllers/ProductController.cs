using Microsoft.AspNetCore.Mvc;

using backend.Models;

namespace backend.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationContext _context;
    public ProductController(ApplicationContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return _context.Products.ToList();
    }
}
