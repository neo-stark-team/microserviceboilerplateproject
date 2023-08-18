using System;  
using System.Collections;
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
namespace dotnetapp.Models  
{  
    public class BookRepository
    {  
        private static List<Book> books = new List<Book>();  

        public List<Book> GetAllBooks()
        {
            return books;
        }
        public Book AddBook(Book newBook)
        {
            Book book = new Book();
            book.BookId=newBook.BookId;
            book.BookName=newBook.BookName;
            book.Category=newBook.Category;
            book.Price=newBook.Price;
            books.Add(book);
            return book;
        }
    }
} 