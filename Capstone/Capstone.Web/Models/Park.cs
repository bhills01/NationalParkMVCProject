using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int Elevation { get; set; }
        public int ElevationFeet { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public decimal EntryFee { get; set; }

        public static explicit operator Park(string v)
        {
            throw new NotImplementedException();
        }

        public int NumberOfAnimalSpecies { get; set; }

        public Park()
        {

        }

        public Park(string parkCode, string parkName, string state, int acreage, int elevation, int elevationFeet, double milesOfTrail, int numberOfCampites,
    string climate, int yearFounded, int annualVisitorCount, string inspirationalQuote, string inspirationalQuoteSource, string parkDescription, decimal entryFee)
        {
            ParkCode = parkCode;
            ParkName = parkName;
            State = state;
            Acreage = acreage;
            Elevation = elevation;
            ElevationFeet = elevationFeet;
            MilesOfTrail = milesOfTrail;
            NumberOfCampsites = numberOfCampites;
            Climate = climate;
            YearFounded = yearFounded;
            AnnualVisitorCount = annualVisitorCount;
            InspirationalQuote = inspirationalQuote;
            InspirationalQuoteSource = inspirationalQuoteSource;
            ParkDescription = parkDescription;
            EntryFee = entryFee;
        }
    }

}
