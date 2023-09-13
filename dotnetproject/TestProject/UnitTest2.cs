// using NUnit.Framework;
// using dotnetwebapiMain.Controllers;
// using dotnetwebapiMain.Models;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using System.Net.Http;
// using Newtonsoft.Json;
// using System.Threading.Tasks;
// using System.Text;

// namespace dotnetwebapiMain.Tests
// {
//     [TestFixture]
//     public class CustomerAdditionControllerTests
//     {
//         private CustomerAdditionController _customAdditionController;
//         private HttpClient _httpClient;

//         [SetUp]
//         public void Setup()
//         {
//             // Create an instance of the BookController
//             _customAdditionController = new CustomerAdditionController();

//             // Create an HttpClient instance with custom handler for bypassing certificate validation
//             var httpClientHandler = new HttpClientHandler();
//             httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
//             _httpClient = new HttpClient(httpClientHandler);
//         }
// [TearDown]
//         public void TearDown()
//         {
//             // Dispose of the HttpClient
//             _httpClient.Dispose();
//         }
//         [Test]
//         public async Task AddCustomer_ValidCustomer_ReturnsOk()
//         {
//             // Arrange
//            // var controller = new CustomerAdditionController();
//             var customer = new Customer {
//                 //CustomerId = 1,
//                 CustomerName = "Customer 1",
//                 Email = "customer1@example.com",
//                 MobileNumber = "1234567890"
//              };

//             // Act
//             var result = await _customAdditionController.AddCustomer(customer) as OkObjectResult;

//             // Assert
//             Assert.IsNotNull(result);
//             Assert.AreEqual(200, result.StatusCode);
//             // You can add more specific assertions if needed
//         }

//         [Test]
//         public async Task AddCustomer_InvalidCustomer_ReturnsBadRequest()
//         {
//             // Arrange
//            // var controller = new CustomerAdditionController();
//             var customer = new Customer {
//                 //CustomerId = -1,
//                 CustomerName = "Customer 1",
//                 Email = "customer1@example.com",
//                 MobileNumber = "1234567890"
//              };

//             // Act
//             var result = await _customAdditionController.AddCustomer(customer) as BadRequestObjectResult;

//             // Assert
//             Assert.IsNotNull(result);
//             Assert.AreEqual(400, result.StatusCode);
//             // You can add more specific assertions if needed
//         }


//     }
// }
