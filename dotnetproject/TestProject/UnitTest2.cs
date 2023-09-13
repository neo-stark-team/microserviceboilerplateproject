using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using dotnetmvcapp.Controllers;
using dotnetmvcapp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;

namespace dotnetmvcapp.Tests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _bookController;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            // Create an instance of the BookController
            _bookController = new BookController();

            // Create an HttpClient instance with custom handler for bypassing certificate validation
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(httpClientHandler);
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of the HttpClient
            _httpClient.Dispose();
        }

       [Test]
public void Index_ReturnsViewWithListOfBooks()
{
    // Act
    var result = _bookController.Index();

    // Assert
    Assert.IsInstanceOf<ViewResult>(result);

    var viewResult = (ViewResult)result;
    Assert.IsInstanceOf<List<Book>>(viewResult.Model);
}

[Test]
public void Search_ValidId_ReturnsViewWithBook()
{
    // Arrange
    int validId = 1; // Replace with a valid book ID

    // Act
    var result = _bookController.Search(validId);

    // Assert
    Assert.IsInstanceOf<ViewResult>(result);

    var viewResult = (ViewResult)result;
    Assert.IsInstanceOf<List<Book>>(viewResult.Model);
    Assert.IsTrue(((List<Book>)viewResult.Model).Count > 0);
}

[Test]
public void Search_InvalidId_ReturnsViewWithEmptyList()
{
    // Arrange
    int invalidId = -1; // Replace with an invalid book ID

    // Act
    var result = _bookController.Search(invalidId);

    // Assert
    Assert.IsInstanceOf<ViewResult>(result);

    var viewResult = (ViewResult)result;
    Assert.IsInstanceOf<List<Book>>(viewResult.Model);
    Assert.AreEqual(0, ((List<Book>)viewResult.Model).Count);
}
[Test]
public void Search_NonexistentId_ReturnsNotFound()
{
    // Arrange
    int nonexistentId = 9999; // Replace with a non-existent book ID

    // Act
     var result = _bookController.Search(nonexistentId);
    Assert.IsInstanceOf<ViewResult>(result);

    var viewResult = (ViewResult)result;
    Assert.IsInstanceOf<List<Book>>(viewResult.Model);
    Assert.AreEqual(0, ((List<Book>)viewResult.Model).Count);
}

[Test]
public void Search_ValidId_ReturnsCorrectBook()
{
    // Arrange
    int validId = 3; // Replace with a valid book ID

    // Act
    var result = _bookController.Search(validId);

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<ViewResult>(result);

    var viewResult = (ViewResult)result;
    Assert.IsInstanceOf<List<Book>>(viewResult.Model);
    Assert.AreEqual(1, ((List<Book>)viewResult.Model).Count);
}
    }
}
