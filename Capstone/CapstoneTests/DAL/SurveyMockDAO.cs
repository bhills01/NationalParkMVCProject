using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.DAL
{
    class SurveyMockDAO : ISurveySQLDAO
    {
        public IList<SurveyResult> GetAllSurveys()
        {
            throw new NotImplementedException();
        }

        public void SaveSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
