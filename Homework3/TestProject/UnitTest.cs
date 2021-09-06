using Homework3.Controllers;
using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Collections.Generic;
using Homework3;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void WeatherForecastControllerGetMethodTest()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get().Result as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal((int)System.Net.HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result.Value);
        }
    }
}
