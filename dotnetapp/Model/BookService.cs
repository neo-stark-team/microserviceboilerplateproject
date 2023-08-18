using System.Collections.Generic;

namespace dotnetapp.Models
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book SaveBook(Book book);
    }

    public class BookService : IBookService
    {
        private BookRepository repository;

        public BookService(BookRepository repository)
        {
            this.repository = repository;
        }

        public Book SaveBook(Book book)
        {
            return repository.AddBook(book); // Corrected parameter name here
        }

        public List<Book> GetBooks()
        {
            return repository.GetAllBooks();
        }
    }
}
