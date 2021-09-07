using Homework2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace XUnitTestProject
{
    public class HomeControllerUnitTest
    {
        [Fact]
        public void HomeController_Index_ReturnsViewResult()
        {
            // arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger.Object);

            // act
            var result = (object)controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void HomeController_Index_StringMessageInViewbag()
        {
            // arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger.Object);

            // act
            controller.Index();

            // assert
            Assert.Equal("Hello world!", controller.ViewBag.Message);
        }
    }
}
