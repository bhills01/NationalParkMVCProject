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
                cmd.ExecuteNonQuery();
            }

        }
        public IList<SurveyResult> GetAllSurveys()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(@"
                     SELECT p.parkName, sr.parkCode, COUNT(sr.parkcode) as votes
                     FROM survey_result sr
                     JOIN park p ON p.parkCode = sr.parkCode
                     GROUP BY p.parkName, sr.parkCode
                     Order by votes desc", connection);

                SqlDataReader reader = cmd.ExecuteReader();

                List<SurveyResult> surveyResults = new List<SurveyResult>();

                while (reader.Read())
                {
                    SurveyResult survey = new SurveyResult();
                    survey.ParkName = Convert.ToString(reader["parkName"]);
                    survey.ParkCode = Convert.ToString(reader["parkCode"]);
                    survey.Votes = Convert.ToInt32(reader["votes"]);
                    surveyResults.Add(survey);
                }
                return surveyResults;
            }
        }
    }
}
