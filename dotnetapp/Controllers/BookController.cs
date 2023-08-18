using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    static readonly IBookRepository bookService = new BookRepository();
    public BookController(IBookRepository _bookService)
    {
       this.bookService = _bookService;
    }
    
}
