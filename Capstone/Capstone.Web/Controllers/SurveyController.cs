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
            Survey newSurvey = new Survey();
            return View(newSurvey);
        }
        public IActionResult MakeNewSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            surveyDAO.SaveSurvey(survey);
            return RedirectToAction("SurveyResults");
        }

        public IActionResult SurveyResults()
        {
            IList<SurveyResult> surveys = surveyDAO.GetAllSurveys();
            return View(surveys);
        }
    }
}