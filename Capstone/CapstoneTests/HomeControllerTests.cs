using Capstone.Web.Controllers;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using CapstoneTests.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            ParkMockDAO parkDAO = new ParkMockDAO();
            WeatherMockDAO weatherDAO = new WeatherMockDAO();
            HomeController controller = new HomeController(parkDAO, weatherDAO);

            // Act
            IActionResult result = controller.Index();

            // Assert 
            ViewResult vr = result as ViewResult;
            Assert.IsNotNull(vr, "Index did not return a ViewResult");
        }


        // This fails with an exception, not sure how to get around session in HomeController
        [TestMethod]
        public void TestDetail()
        {
            // Arrange
            ParkMockDAO parkDAO = new ParkMockDAO();
            WeatherMockDAO weatherDAO = new WeatherMockDAO();
            HomeController controller = new HomeController(parkDAO, weatherDAO);

            // Act
            IActionResult resultFahrenheit = controller.Detail("CVNP", "F");
            IActionResult resultCelcius = controller.Detail("CVNP", "C");

            // Assert
            ViewResult vr1 = resultFahrenheit as ViewResult;
            Weather vr1Result = vr1.Model as Weather;
            Assert.IsNotNull(vr1, "Search did not reuturn a Detail View");

            Assert.AreEqual(65, vr1Result.High);
            Assert.AreEqual(34, vr1Result.High);

            ViewResult vr2 = resultCelcius as ViewResult;
            Weather vr2Result = vr1.Model as Weather;
            Assert.IsNotNull(vr2, "Search did not reuturn a Detail View");

            Assert.AreEqual(18, vr1Result.High);
            Assert.AreEqual(1, vr1Result.High);
        }
    }
}
