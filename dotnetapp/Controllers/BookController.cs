using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
namespace dotnetapp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    static readonly IBookRepository bookService = new BookRepository();
    /*public BookController(IBookRepository _bookService)
    {
       this.bookService = _bookService;
    }*/
    //GET /api/books:
    [HttpGet("/api/books/")]
    public IEnumerable<Book> GetAll()
    {
        var bookList = bookService.GetAll();
        return bookList;
    }

    [HttpPost("/api/books/")]
    public bool AddBook(Book newBook)
    {         
        return bookService.Add(newBook);
    } 
}
