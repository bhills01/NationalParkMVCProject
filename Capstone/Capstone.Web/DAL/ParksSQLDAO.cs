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
    }
}
