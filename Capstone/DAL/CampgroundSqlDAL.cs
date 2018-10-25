using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class CampgroundSqlDAL : ICampgroundDAL
    {
        private string connectionString;

        public CampgroundSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Campground> GetCampgrounds(int parkId)
        {
            List<Campground> campgrounds = new List<Campground>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM campground WHERE park_id = @park_id;", conn);
                    command.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground campground = ConvertRowToCampground(reader);
                        campgrounds.Add(campground);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error reading campground data...");
                throw;
            }
            return campgrounds;
        }

        private Campground ConvertRowToCampground(SqlDataReader reader)
        {
            Campground campground = new Campground();
            campground.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            campground.DailyFee = Convert.ToDecimal(reader["daily_fee"]);
            campground.Name = Convert.ToString(reader["name"]);
            campground.OpenFrom = Convert.ToInt32(reader["open_from_mm"]);
            campground.OpenTo = Convert.ToInt32(reader["open_to_mm"]);
            campground.ParkId = Convert.ToInt32(reader["park_id"]);
            return campground;
        }
    }
}
