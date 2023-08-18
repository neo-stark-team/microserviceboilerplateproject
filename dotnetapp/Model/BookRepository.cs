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
        public IItemRepostory()  
        {  
            Add(new Book { Name = "Book1", Category = "Fiction", Price = 100});  
            Add(new Book { Name = "Book2", Category = "Story", Price = 150 });  
            Add(new Book { Name = "Book3", Category = "Fiction", Price = 200});  
        }  
        public IEnumerable<Book> GetAll()  
        {  
            return books;  
        }  
        public Book Get(int id)  
        {  
            return books.Find(p => p.Id == id);  
        }  
        public Book Add(Book item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
            item.Id = _nextId++;  
            books.Add(item);  
            return item;  
        }  
        public void Remove(int id)  
        {  
            books.RemoveAll(p => p.Id == id);  
        }  
        public bool Update(Book item)  
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
            books.Add(item);  
            return true;  
        }  
    }  
} 