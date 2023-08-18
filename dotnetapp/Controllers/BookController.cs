using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
namespace dotnetapp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{    
    private readonly BookService service;

    public BookController(BookService service)
    {
        this.service = service;
    }

    [HttpPost]
    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        var addedProduct = service.SaveProduct(product);
        return Ok(addedProduct);
    }

    [HttpGet]
    public ActionResult<List<Product>> FindAllProducts()
    {
        var products = service.GetProducts();
        return Ok(products);
    }
}
