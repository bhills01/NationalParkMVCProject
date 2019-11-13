using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkVM
    {
        public ParkVM(Park park, IList<Weather> weather)
        {
            Park = park;
            Weather = weather;
        }

        public Park Park { get; set; }
        public IList<Weather> Weather { get; set; }
    }
}
