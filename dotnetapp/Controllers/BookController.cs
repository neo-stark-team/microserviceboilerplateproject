using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
namespace dotnetapp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    
    //GET /api/books:
    [HttpGet("/api/books/")]
    public IEnumerable<Book> GetAll()
    {
        var bookList = new List<Book>();
        return bookList;
    }

    [HttpPost("/api/books/")]
    public bool AddBook(Book newBook)
    {        
       
        return true;
    } 
}
