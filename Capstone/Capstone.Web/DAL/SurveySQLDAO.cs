using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySQLDAO: ISurveySQLDAO
    {
        private readonly string connectionString;

        public SurveySQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void SaveSurvey(Survey survey)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"
                    INSERT survey_result (parkCode, emailAddress, state, activityLevel)
                    VALUES (@parkCode, @email, @state, @activity)", connection);
                cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                cmd.Parameters.AddWithValue("@email", survey.Email);
                cmd.Parameters.AddWithValue("@state", survey.StateOfResidence);
                cmd.Parameters.AddWithValue("@activity", survey.ActivityLevel);
            }

        }
        public IList<Survey> GetAllSurveys()
        {
            return null;
        }
    }
}
