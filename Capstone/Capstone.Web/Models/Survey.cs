using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Email { get; set; }
        public string StateOfResidence { get; set; }
        public string ActivityLevel { get; set; }
        public string ParkCode { get; set; }
    }
}
