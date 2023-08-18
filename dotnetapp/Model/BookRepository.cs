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
            Add(new Book { Name = "Tomato", Category = "Vagitable", Price = 100});  
            Add(new Book { Name = "Apple", Category = "Fruit", Price = 150 });  
            Add(new Book { Name = "Suit", Category = "Cloth", Price = 200});  
        }  
        public IEnumerable<Book> GetAll()  
        {  
            return items;  
        }  
        public Book Get(int id)  
        {  
            return items.Find(p => p.Id == id);  
        }  
        public Book Add(Book item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
            item.Id = _nextId++;  
            items.Add(item);  
            return item;  
        }  
        public void Remove(int id)  
        {  
            items.RemoveAll(p => p.Id == id);  
        }  
        public bool Update(Book item)  
        {  
            if (item == null)  
            {  
                throw new ArgumentNullException("item");  
            }  
            int index = items.FindIndex(p => p.Id == item.Id);  
            if (index == -1)  
            {  
                return false;  
            }  
            items.RemoveAt(index);  
            items.Add(item);  
            return true;  
        }  
    }  
} 