using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
   public class WeatherSQLDAO : IWeatherSQLDAO
   {
      private readonly string connectionString;

      public WeatherSQLDAO(string connectionString)
      {
        this.connectionString = connectionString;
      }

            /// <summary>
            /// Generates a list of all Forecasts
            /// </summary>
            /// <returns>IList<Park></Park></returns>
      public IList<Weather> GetWeather(string parkCode)
      {
        List<Weather> forecast = new List<Weather>();

          try
          {
              using (SqlConnection conn = new SqlConnection(connectionString))
              {
                   conn.Open();

                        

                SqlCommand cmd = new SqlCommand(@"SELECT *
                                        FROM park p
                                        JOIN weather w ON w.parkCode = p.parkCode
                                        WHERE p.parkCode = @parkCode
                                        ORDER BY w.fiveDayForecastValue", conn);

                cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Weather weather = new Weather();

                    weather.ParkCode = Convert.ToString(reader["parkCode"]);
                    weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                    weather.Low = Convert.ToInt32(reader["low"]);
                    weather.High = Convert.ToInt32(reader["high"]);
                    weather.Forecast = Convert.ToString(reader["forecast"]);
                    forecast.Add(weather);
                }
              }
          }
          finally
          {
          }
          return forecast;
      }     
   }
}
