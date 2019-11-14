using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IParksSQLDAO parkDAO;
        private ISurveySQLDAO surveyDAO;

        public SurveyController(IParksSQLDAO parkDAO, ISurveySQLDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.surveyDAO = surveyDAO;
        }
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }
        public IActionResult MakeNewSurvey(string parkCode, string email, string state, string activity)
        {
            Survey newSurvey = new Survey();
            newSurvey.ParkCode = parkCode;
            newSurvey.Email = email;
            newSurvey.StateOfResidence = state;
            newSurvey.ActivityLevel = activity;
            surveyDAO.SaveSurvey(newSurvey);
            return RedirectToAction("Index");
        }
    }
}