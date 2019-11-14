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
        private IWeatherSQLDAO weatherSQLDAO;

        public SurveyController(IParksSQLDAO parkDAO, IWeatherSQLDAO weatherSQLDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherSQLDAO = weatherSQLDAO;
        }
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }
    }
}