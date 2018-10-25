using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString;

        // Constructor
        public ParkSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Park> GetParks()
        {
            List<Park> parks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open connection
                    conn.Open();

                    // Create the command
                    SqlCommand command = new SqlCommand("SELECT * FROM park ORDER BY name ASC;", conn);

                    // Execute the command
                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Park park = ConvertRowToPark(reader);
                        parks.Add(park);
                    }
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error reading park data");
                throw;
            }
            return parks;
        }

        public IList<Park> GetParks(string name)
        {
            throw new NotImplementedException();
        }

        private Park ConvertRowToPark(SqlDataReader reader)
        {
            Park park = new Park();
            park.Area = Convert.ToInt32(reader["area"]);
            park.Description = Convert.ToString(reader["description"]);
            park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
            park.Location = Convert.ToString(reader["location"]);
            park.Name = Convert.ToString(reader["name"]);
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.Visitors = Convert.ToInt32(reader["visitors"]);
            return park;
        }

        
        //public IList<Park> GetParks(string name)
        //{
        //    throw NotImplementedException;
        //}
    }
}
