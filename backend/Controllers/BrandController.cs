using Microsoft.AspNetCore.Mvc;

using backend.Models;
namespace backend.Controllers;


public class BrandToCreate
{
    public string Name = null!;
}

[ApiController]
[Route("api/brands")]
public class BrandController : ControllerBase
{
    private readonly ApplicationContext _context;
    public BrandController(ApplicationContext context)
    {
        this._context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreateBrand(BrandToCreate brand)
    {
        if (brand.Name.Length == 0) return BadRequest("The name cannot be empty");
        var newBrand = new Brand()
        {
            Name = brand.Name,
        };
        await _context.Brands.AddAsync(newBrand);
        await _context.SaveChangesAsync();
        return CreatedAtAction("", new { id = newBrand.Id }, newBrand);
    }

}
