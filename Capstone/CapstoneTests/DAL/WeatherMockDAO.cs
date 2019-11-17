using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneTests.DAL
{
    class WeatherMockDAO : IWeatherSQLDAO
    {
        private List<Weather> weathers = new List<Weather>()
        {
            new Weather("CVNP", 1, 65, 34, "rain"),
            new Weather("YOYO", 3, 45, 23, "sunny"),
            new Weather("CAST", 4, 87, 76, "snow")
        };

        public IList<Weather> GetAllWeather()
        {
            return new List<Weather>(weathers);
        }
        public IList<Weather> GetWeather(string parkCode)
        {
            IList<Weather> weathers = GetAllWeather();
            IList<Weather> foundWeather = null;

            foreach(Weather weather in weathers)
            {
                if(weather.ParkCode == parkCode)
                {
                    foundWeather.Add(weather);
                }
            }
            return new List<Weather>(foundWeather);
        }
    }
}
