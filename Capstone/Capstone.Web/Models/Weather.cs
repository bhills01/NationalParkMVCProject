using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
        public string Forecast { get; set; }

        public double GetHigh(string unit)
        {
            if (unit == "C")
            {
                High = (High - 32) * (5 / 9.0);
            }

            return High;
        }

        public double GetLow(string unit)
        {
            if (unit == "C")
            {
                Low = (Low - 32) * (5 / 9.0);
            }

            return Low;
        }
    }
}
