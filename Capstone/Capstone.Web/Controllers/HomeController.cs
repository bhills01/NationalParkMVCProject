using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParksSQLDAO parkDAO;
        private IWeatherSQLDAO weatherSQLDAO;

        public HomeController(IParksSQLDAO parkDAO, IWeatherSQLDAO weatherSQLDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherSQLDAO = weatherSQLDAO;
        }
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetParks();
            return View(parks);
        }
        public IActionResult Detail(string parkCode, string unitPref)
        {

            if (unitPref == null)  
            {
                string sessionString = HttpContext.Session.GetString("UnitPref");
                unitPref = sessionString == null ? "F" : sessionString;
            }
            else
            {
                HttpContext.Session.SetString("UnitPref", unitPref);

            }

            Park park = new Park();
            park = parkDAO.GetParksByCode(parkCode);
            IList<Weather> weather;
            weather = weatherSQLDAO.GetWeather(parkCode);
            ParkVM parkView = new ParkVM(park, weather);

            parkView.UnitPref = unitPref;
            return View(parkView);
        }
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
