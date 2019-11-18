using Capstone.Web.Controllers;
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
    public class SurveyControllerTests
    {
        [TestMethod]
        public void TestIndex()
        {

            // Arrange
            ParkMockDAO parkDAO = new ParkMockDAO();
            SurveyMockDAO surveyDAO = new SurveyMockDAO();
            SurveyController controller = new SurveyController(parkDAO, surveyDAO);

            // Act 
            IActionResult result = controller.Index();

            // Assert
            ViewResult vr = result as ViewResult;
            Assert.IsNotNull(vr, "Index did not return a ViewResult");
        }



        [TestMethod]
        public void TestSurveyResults()
        {
            // Arrange
            ParkMockDAO parkDAO = new ParkMockDAO();
            SurveyMockDAO surveyDAO = new SurveyMockDAO();
            SurveyController controller = new SurveyController(parkDAO, surveyDAO);

            // Act
            Survey newSurvey = new Survey()
            {
                ParkCode = "YOSE",
                Email = "craig@earthlink.net",
                ActivityLevel = "Active",
                StateOfResidence = "California",
            };
            surveyDAO.SaveSurvey(newSurvey);
            IActionResult result = controller.SurveyResults();

            // Assert
            ViewResult vr = result as ViewResult;
            Assert.IsNotNull(vr, "SurveyResults did not return a View");

            IList<SurveyResult> surveyResults = vr.Model as IList<SurveyResult>;
            Assert.IsNotNull(surveyResults, "ViewResult.Model is not an IList<SurveyResult>");
            Assert.AreEqual(4, surveyResults.Count);
        }
    }
}
