// using Microsoft.Extensions.Logging.Abstractions.Testing;
// using NUnit.Framework;
// using dotnetapp.Models;
// using dotnetapp.Controllers;

// [TestFixture]
// public class CategoriesControllerTests
// {
//     private CategoriesController _controller;
//     private MockLogger<CategoriesController> _logger;

//     [SetUp]
//     public void Setup()
//     {
//         _logger = new MockLogger<CategoriesController>();
//         _controller = new CategoriesController(_logger.Logger);
//     }

//     [Test]
//     public void TestCategoryCreationLogging()
//     {
//         // Perform the action that triggers logging.
//         var category = new Category { Name = "Test Category" };
//         var result = _controller.PostCategory(category);

//         // Assert log messages
//         Assert.IsTrue(_logger.HasLog(LogLevel.Information, "Category created successfully."));
//         Assert.IsFalse(_logger.HasLog(LogLevel.Error, "Error creating category."));
//     }
// }
