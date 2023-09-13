using NUnit.Framework;
using dotnetmsAddCustomer.Controllers;
using dotnetmsAddCustomer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace dotnetmsAddCustomer.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _controller;
        private CustomerDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new CustomerDbContext(options);
            _controller = new CustomerController(_dbContext);
        }

        [Test]
        public async Task AddCustomer_ValidCustomer_ReturnsOkResult()
        {
            // Arrange
            var customer = new Customer
            {
                //CustomerId = 1,
                CustomerName = "Customer 1",
                Email = "customer1@example.com",
                MobileNumber = "9876543210"
            };

            // Act
            var result = await _controller.AddCustomer(customer);

            // Assert
            Assert.IsInstanceOf<OkResult>(result); // Ensure it's an OkResult
        }
        [Test]
        public async Task AddCustomer10_ValidCustomer_ReturnsOkResult()
        {
            // Arrange
            var customer = new Customer
            {
                //CustomerId = 10,
                CustomerName = "Customer 10",
                Email = "customer10@example.com",
                MobileNumber = "9876543210"
            };

            // Act
            var result = await _controller.AddCustomer(customer);

            // Assert
            Assert.IsInstanceOf<OkResult>(result); // Ensure it's an OkResult
        }

        [TearDown]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
