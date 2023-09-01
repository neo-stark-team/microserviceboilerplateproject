using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.Extensions.Logging;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly BookDbContext _context;
private readonly ILogger<CategoriesController> _logger;
    public CategoriesController(BookDbContext context,ILogger<CategoriesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // 1. Retrieve a list of all categories.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categories = await _context.Categories.Include(c => c.Books).ToListAsync();

    return categories;
    }

    // 2. Retrieve a specific category by its ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await _context.Categories.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        return category;
    }

    // 3. Create a new category.
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
        // _context.Categories.Add(category);
        // await _context.SaveChangesAsync();

        // return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        try
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Category created successfully.");
        return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error creating category.");
        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the category.");
    }
    }

    // 4. Update an existing category by its ID.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        _context.Entry(category).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // 5. Delete a category by its ID.
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}
