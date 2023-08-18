using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
namespace dotnetapp.Models  
{  
    public class BookRepository :IBookRepository  
    {  
        private List<Book> books = new List<Book>();  
        private int _nextId = 1;  
        public BookRepository()  
        {  
            AddBook(new Book { Name = "Book1", Category = "Fiction", Price = 100});  
            AddBook(new Book { Name = "Book2", Category = "Story", Price = 150 });  
            AddBook(new Book { Name = "Book3", Category = "Fiction", Price = 200});  
        }  
        public IEnumerable<Book> GetAll()  
        {  
            return books;  
        }  
        public Book GetBook(int id)  
        {  
            return books.Find(p => p.Id == id);  
        }  
        public Book AddBook(Book item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
            item.Id = _nextId++;  
            books.AddBook(item);  
            return item;  
        }  
        public void RemoveBook(int id)  
        {  
            books.RemoveAll(p => p.Id == id);  
        }  
        public bool UpdateBook(Book item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
            int index = books.FindIndex(p => p.Id == item.Id);  
            if (index == -1)  
            {  
                return false;  
            }  
            books.RemoveAt(index);  
            books.AddBook(item);  
            return true;  
        }  
    }  
} 