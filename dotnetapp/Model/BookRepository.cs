using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
namespace dotnetapp.Models  
{  
    public class BookRepository :IBookRepository  
    {  
        private List<Book> books = new ArrayList<Book>();  
        
    }
} 