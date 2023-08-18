using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
namespace dotnetapp.Models  
{  
    interface IBookRepository  
    {  
        IEnumerable<Book> GetAll();  
        Book Get(int id);  
        Book Add(Book bookObj);  
        void Remove(int id);  
        bool Update(Book bookObj);  
    }  
} 