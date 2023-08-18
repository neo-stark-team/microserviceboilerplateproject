using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
namespace dotnetapp.Models  
{  
    public class BookRepository :IBookRepository  
    {  
        private List<Book> books = new ArrayList<Book>();  

        public List<Book> getAllBooks()
        {
            return books;
        }
        public Book AddBook(Book newBook)
        {
            Book book = new Book();
            book.BookId(newBook.BookId());
            book.BookName(newBook.BookName());
            book.Category(newBook.Category());
            book.Price(newBook.Price());
            books.add(book);
            return book;
        }
    }
} 