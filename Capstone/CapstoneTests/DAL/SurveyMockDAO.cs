using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapstoneTests.DAL
{
    class SurveyMockDAO : ISurveySQLDAO
    {
        private List<Survey> surveys = new List<Survey>()
        {
            new Survey(1, "bob@bob.com", "Ohio", "Active", "CVNP"),
            new Survey(2, "shirley@shirley.com", "Kentucky", "Very Active", "CVNP"),
            new Survey(3, "brad@brad.com", "Arizona", "Lazy", "CVNP")
        };

        private List<SurveyResult> surveyResults = new List<SurveyResult>()
        {
            new SurveyResult("Cuyahoga", "CVNP", 1),
            new SurveyResult("Yellowstone", "YSNP", 2),
            new SurveyResult("Everglades", "EGNP", 3)
        };

        public int MaxID
        {
            get
            {
                return surveys.Max(s => s.SurveyId);
            }
        }
        public IList<SurveyResult> GetAllSurveys()
        {
            return new List<SurveyResult>(surveyResults);
        }

        public void SaveSurvey(Survey survey)
        {
            survey.SurveyId = MaxID + 1;
            SurveyResult newSurveyResult = new SurveyResult("Yosemite", survey.ParkCode, 1);
            surveyResults.Add(newSurveyResult);            
        }

    }
}
