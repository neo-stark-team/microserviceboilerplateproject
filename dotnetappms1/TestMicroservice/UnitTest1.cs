using System;
using System.Collections.Generic;
using NUnit.Framework;
using dotnetappms1.Controllers;

namespace dotnetappms1.Tests
{
    [TestFixture]
    public class StudentAdmissionControllerTests
    {
        [Test]
        public void Get_ReturnsListOfStudentAdmissionDetails()
        {
            // Arrange
            var controller = new StudentAdmissionController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<StudentAdmissionDetailsModel>>(result);

            var admissionList = (IEnumerable<StudentAdmissionDetailsModel>)result;
            Assert.AreEqual(2, admissionList.Count());

            // You can add more specific assertions if needed, e.g., check the properties of each student.
        }
         
    }
    
}
