using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParksSQLDAO : IParksSQLDAO
    {
        private readonly string connectionString;

        public ParksSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Generates a list of all Parks
        /// </summary>
        /// <returns>IList<Park></Park></returns>
        public IList<Park> GetParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT * FROM park";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                            Park park = new Park();

                            park.ParkCode = Convert.ToString(reader["parkCode"]);
                            park.ParkName = Convert.ToString(reader["parkName"]);
                            park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                            parks.Add(park);
                    }
                }
            }
            finally
            {
            }
            return parks;
        }

        public Park GetParksByCode(string parkCode)
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                                      
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM park where parkCode = @parkCode", conn);

                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    }
                }
            }
            finally
            {
            }
            return park;
        }
    }
}
