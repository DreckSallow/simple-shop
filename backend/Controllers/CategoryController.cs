using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using backend.Models;
namespace backend.Controllers;


public class CategoryToCreate
{
    public string Name = null!;
}

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ApplicationContext _context;
    public CategoryController(ApplicationContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _context.Categories.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory(CategoryToCreate ct)
    {
        if (ct.Name.Length == 0) return BadRequest("The name cannot be empty");
        var category = new Category()
        {
            Name = ct.Name,
        };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction("", new { id = category.Id }, category);
    }

}
