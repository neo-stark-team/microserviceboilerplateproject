using NUnit.Framework;
using dotnetwebapiproject.Controllers;
using dotnetwebapiproject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace dotnetwebapiproject.Tests
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

            // Add some test data to the in-memory database
            _dbContext.Customers.Add(new Customer
            {
                CustomerId = 1,
                CustomerName = "Customer 1",
                Email = "customer1@example.com",
                MobileNumber = "1234567890"
            });

            _dbContext.Customers.Add(new Customer
            {
                CustomerId = 2,
                CustomerName = "Customer 2",
                Email = "customer2@example.com",
                MobileNumber = "9876543210"
            }); _dbContext.SaveChanges();
        }

        [Test]
        public void GetCustomers_ReturnsListOfCustomers()
        {
            // Act
            var result = _controller.GetCustomers();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result); // Check if the result is an OkObjectResult
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            Assert.IsInstanceOf<IEnumerable<Customer>>(okResult.Value);
            var customers = okResult.Value as IEnumerable<Customer>;
            Assert.IsNotNull(customers); // Ensure the customer list is not null
            Assert.AreEqual(2, customers.Count());
        }


        [Test]
        public async Task GetById_ExistingCustomerId_ReturnsCustomer()
        {
            // Arrange
            var customerId = 1;

            // Act
            var result = await _controller.GetById(customerId);

            // Assert
            Assert.IsNotNull(result); // Ensure the ActionResult is not null
            Assert.IsInstanceOf<ActionResult<Customer>>(result); // Ensure it's an ActionResult<Customer>
            Assert.IsInstanceOf<OkObjectResult>(result.Result); // Ensure it's an OkObjectResult

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var customer = okResult.Value as Customer;
            Assert.IsNotNull(customer); // Ensure the Customer object is not null
            Assert.AreEqual(customerId, customer.CustomerId);
        }

        [Test]
        public async Task GetById_NonExistingCustomerId_ReturnsNotFound()
        {
            // Arrange
            var customerId = 999;

            // Act
            var result = await _controller.GetById(customerId);

            // Assert
            Assert.IsInstanceOf<ActionResult<Customer>>(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [TearDown]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}