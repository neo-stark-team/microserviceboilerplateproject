using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
namespace dotnetapp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{    
    private readonly BookService service;

    public BookController(BookService _bookService)
    {
        this.service = _bookService;
    }

    [HttpPost]
    public ActionResult<Book> AddBook([FromBody] Book Book)
    {
        var addedBook = service.SaveBook(Book);
        return Ok(addedBook);
    }

    [HttpGet]
    public ActionResult<List<Book>> FindAllBooks()
    {
        var Books = service.GetBooks();
        return Ok(Books);
    }
}
