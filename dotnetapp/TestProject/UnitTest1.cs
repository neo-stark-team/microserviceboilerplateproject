using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;

[TestFixture]
public class CategoriesControllerTests
{
    private CategoriesController _controller;
    private Mock<ILogger<CategoriesController>> _loggerMock;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<CategoriesController>>();
        _controller = new CategoriesController(_loggerMock.Object);
    }

    [Test]
    public void TestCategoryCreationLogging()
    {
        // Arrange
        var category = new Category { Name = "Test Category" };

        // Act
        var result = _controller.PostCategory(category);

        // Assert
        // You can add any necessary assertions on the result here

        // Verify log messages
        _loggerMock.Verify(
            logger => logger.LogInformation("Category created successfully."),
            Times.Once);

        // You can also verify other log levels if needed
        _loggerMock.Verify(
            logger => logger.LogError(It.IsAny<string>()),
            Times.Never);
    }
}
