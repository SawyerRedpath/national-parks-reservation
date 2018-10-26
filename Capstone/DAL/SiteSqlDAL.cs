using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class SiteSqlDAL : ISiteDAL
    {
        private string connectionString;

        // Constructor
        public SiteSqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        // Gets a list of sites that are available for reservation
        public IList<Site> GetSites(int campgroundId, string fromDate, string toDate)
        {
            // Create a list to return
            List<Site> availableSites = new List<Site>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnectionString.DatabaseString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command
                    // RETURN HERE
                    SqlCommand command = new SqlCommand($"select TOP 5 * from site WHERE campground_id = @campground_id AND site.site_id NOT IN (select site.site_id from site inner join reservation on site.site_id = reservation.site_id WHERE(@from_date BETWEEN from_date AND to_date) AND(@to_date BETWEEN from_date AND to_date) AND(from_date BETWEEN @from_date AND @to_date) AND(to_date BETWEEN @from_date AND @to_date))", conn);
                    command.Parameters.AddWithValue("@from_date", fromDate);
                    command.Parameters.AddWithValue("@to_date", toDate);
                    command.Parameters.AddWithValue("@campground_id", campgroundId);

                    // Execute the command
                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Site site = ConvertRowToSite(reader);
                        availableSites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving site data");
                throw;
            }

            return availableSites;
        }

        private Site ConvertRowToSite(SqlDataReader reader)
        {
            Site site = new Site();
            site.Accessible = Convert.ToInt32(reader["accessible"]);
            site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.MaxRvLength = Convert.ToInt32(reader["max_rv_length"]);
            site.SiteId = Convert.ToInt32(reader["site_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.Utilities = Convert.ToInt32(reader["utilities"]);

            return site;
        }
    }
}
