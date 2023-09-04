using System.Collections.Generic;
using NUnit.Framework;
using msdotnetapp2.Controllers;

namespace msdotnetapp2.Tests
{
    [TestFixture]
    public class StudentAttendanceControllerTests
    {
        [Test]
        public void Get_ReturnsListOfStudentAttendanceDetails()
        {
            // Arrange
            var controller = new StudentAttendanceController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<StudentAttendanceDetailsModel>>(result);

            var attendanceList = (IEnumerable<StudentAttendanceDetailsModel>)result;
            Assert.AreEqual(2, attendanceList.Count());

            // You can add more specific assertions if needed, e.g., check the properties of each student's attendance details.
        }
    }
}
