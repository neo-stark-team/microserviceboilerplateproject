using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
namespace dotnetapp.Models  
{  
    public interface IBookRepository  
    {  
        IEnumerable<Book> GetAll();  
        Book GetBook(int id);  
        Book AddBook(Book bookObj);  
        void RemoveBook(int id);  
        bool UpdateBook(Book bookObj);  
    }  
} 