using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    static readonly IBookRepository bookrepo = new BookRepository();
    public IEnumerable<Book> GetALLBooks()
    {
        
    }
    
}
