using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookDbContext _context;

    public BooksController(BookDbContext context)
    {
        _context = context;
    }

    // 1. Retrieve a list of all books.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    // 2. Retrieve a specific book by its ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    // 3. Retrieve books by author name using query string.
[HttpGet("author")]
public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthorName([FromQuery] string authorName)
{
    var books = await _context.Books.Where(b => b.AuthorName == authorName).ToListAsync();
    return books;
}


    // // 4. Retrieve books with a minimum price using query string.
    // [HttpGet("price")]
    // public async Task<ActionResult<IEnumerable<Book>>> GetBooksByPrice([FromQuery] decimal minPrice)
    // {
    //     var books = await _context.Books.Where(b => b.Price >= minPrice).ToListAsync();
    //     return books;
    // }

    // 5. Create a new book.
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // 6. Update an existing book by its ID.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        _context.Entry(book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(id))
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

    // 7. Delete a book by its ID.
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BookExists(int id)
    {
        return _context.Books.Any(e => e.Id == id);
    }
}
