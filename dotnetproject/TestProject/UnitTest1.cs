using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using dotnetapiapp.Controllers;
using dotnetapiapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapiapp.Tests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _bookController;
        private BookStoreContext _context;

        [SetUp]
        public void Setup()
        {
            // Initialize an in-memory database for testing
            var options = new DbContextOptionsBuilder<BookStoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new BookStoreContext(options);
            _context.Database.EnsureCreated(); // Create the database

            // Seed the database with sample data
            _context.Books.AddRange(new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", Price = 10.99m, Quantity = 5 },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", Price = 12.99m, Quantity = 7 },
                new Book { Id = 3, Title = "Book 3", Author = "Author 3", Price = 9.99m, Quantity = 3 },
            });
            _context.SaveChanges();

            _bookController = new BookController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // Delete the in-memory database after each test
            _context.Dispose();
        }

        [Test]
        public async Task GetAllBooks_ReturnsOkResult()
        {
            // Act
            var result = await _bookController.GetAllBooks();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAllBooks_ReturnsAllBooks()
        {
            // Act
            var result = await _bookController.GetAllBooks();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf<IEnumerable<Book>>(okResult.Value);
            var books = okResult.Value as IEnumerable<Book>;

            var bookCount = books.Count();
            Assert.AreEqual(3, bookCount); // Assuming you have 3 books in the seeded data
        }

        [Test]
        public async Task GetBookById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var existingId = 1;

            // Act
            var result = await _bookController.GetBookById(existingId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetBookById_ExistingId_ReturnsBook()
        {
            // Arrange
            var existingId = 1;

            // Act
            var result = await _bookController.GetBookById(existingId);

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            var book = okResult.Value as Book;
            Assert.IsNotNull(book);
            Assert.AreEqual(existingId, book.Id);
        }

        [Test]
        public async Task GetBookById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var nonExistingId = 99; // Assuming this ID does not exist in the seeded data

            // Act
            var result = await _bookController.GetBookById(nonExistingId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

    }
}
