using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class ReservationSqlDAL : IReservationDAL
    {
        private string connectionString;

        public ReservationSqlDAL(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }
        public (bool,int) AddNewReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnectionString.DatabaseString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command
                    SqlCommand cmd = new SqlCommand("INSERT INTO reservation Values (@site_id, @name, @from_date, @to_date, @create_date);" +
                        "SELECT @@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@site_id", reservation.SiteId);
                    cmd.Parameters.AddWithValue("@name", reservation.Name);
                    cmd.Parameters.AddWithValue("@from_date", reservation.FromDate);
                    cmd.Parameters.AddWithValue("@to_date", reservation.ToDate);
                    cmd.Parameters.AddWithValue("@create_date", DateTime.Now);

                    // Execute the command
                    int newValue = Convert.ToInt32(cmd.ExecuteScalar());

                    return (true, newValue);

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error reading reservation data");
                throw;
            }
        }
    }
}
