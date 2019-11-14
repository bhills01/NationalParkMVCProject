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
            //IList<Park> parks = parkDAO.GetParks();
            Survey newSurvey = new Survey();
            return View(newSurvey);
        }
        public IActionResult MakeNewSurvey(Survey survey)
        {
            //Survey newSurvey = new Survey();
            //newSurvey.ParkCode = parkCode;
            //newSurvey.Email = email;
            //newSurvey.StateOfResidence = state;
            //newSurvey.ActivityLevel = activity;
            surveyDAO.SaveSurvey(survey);
            return RedirectToAction("Index");
        }
    }
}