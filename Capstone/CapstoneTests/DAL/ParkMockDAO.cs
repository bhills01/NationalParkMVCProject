using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneTests.DAL
{
    class ParkMockDAO : IParksSQLDAO
    {
        private List<Park> parks = new List<Park>()
        {
            new Park("CVNP", "Cuyahoga Park", "Ohio", 45833, 3000, 300000, 50, 60, "Tropical", 1901, 100000, "Yay!!!", "Joanna", "It's a cool Place", 10),
            new Park("YOSE", "Yosemite", "Colorado", 23423, 355, 234523, 232, 33, "Forest", 2000, 1234112, "Nope!!!", "Mike Tyson", "Run!!", 45),
        };
        public IList<Park> GetParks()
        {
            return new List<Park>(parks);
        }

        public Park GetParksByCode(string parkCode)
        {
            parkCode = parkCode.Trim().ToLower();
            IList<Park> parks = GetParks();
            Park foundPark = null;
            foreach(Park park in parks)
            {
                if(park.ParkCode == parkCode)
                {
                    foundPark = park;
                }
            }
            return foundPark;
        }
    }
}
