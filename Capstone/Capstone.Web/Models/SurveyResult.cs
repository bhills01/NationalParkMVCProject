using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        public string ParkName { get; set; }
        public string ParkCode { get; set; }
        public int Votes { get; set; }

        public SurveyResult()
        {

        }

        public SurveyResult(string parkName, string parkCode, int votes)
        {
            ParkName = parkName;
            ParkCode = parkCode;
            Votes = votes;
        }
    }
}
