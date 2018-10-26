using Capstone.DAL;
using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class ParkInformationCLI
    {
        private Park park;
        private IList<Campground> campgrounds;

        // Constructor
        public ParkInformationCLI(Park park)
        {
            this.park = park;
        }
        public void Display()
        {
            while (true)
            {
                Console.WriteLine("Park Information Screen");
                PrintParkInformation(park);



                Console.WriteLine();
                Console.WriteLine("Select a Command");
                Console.WriteLine("1) View Campgrounds");
                Console.WriteLine("2) Search for Reservation");
                Console.WriteLine("3) Return to Previous Screen");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine().ToUpper();
                // View Campgrounds
                if (input == "1")
                {
                    Console.WriteLine("Viewing Campgrounds...");
                    campgrounds = GetCampgrounds(park.ParkId);
                    ParkCampgroundsCLI PCCli = new ParkCampgroundsCLI(campgrounds);
                    PCCli.Display();
                }
                // Search for Reservation
                else if (input == "2")
                {
                    Console.WriteLine("Searching for Reservation...");
                    CampgroundReservationCLI CrCli = new CampgroundReservationCLI(campgrounds);
                    CrCli.Display();
                }
                // Return to Previous Screen
                else if (input == "3")
                {
                    Console.WriteLine("Returning to Previous Menu...");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
            }
        }

        private void PrintParkInformation(Park park)
        {
            Console.WriteLine(park.Name);
            Console.WriteLine($"Location: {park.Location.PadLeft(11)}");
            Console.WriteLine($"Established: {park.EstablishDate.ToString().PadLeft(25)}");
            Console.WriteLine($"Area: {park.Area.ToString().PadLeft(16)}");
            Console.WriteLine($"Annual Visitors: {park.Visitors.ToString()}");
            Console.WriteLine();
            Console.WriteLine(park.Description);
            Console.WriteLine();
        }

        private IList<Campground> GetCampgrounds(int parkId)
        {
            ICampgroundDAL campdal = new CampgroundSqlDAL(DatabaseConnectionString.DatabaseString);
            IList<Campground> campgrounds = campdal.GetCampgrounds(parkId);
            return campgrounds;
        }
    }
}
