using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class ParkInformationCLI
    {
        private Park park;

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
                string input = Console.ReadLine();
                // View Campgrounds
                if (input == "1")
                {
                    Console.WriteLine("Viewing Campgrounds...");
                }
                // Search for Reservation
                else if (input == "2")
                {
                    Console.WriteLine("Searching for Reservation...");
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

        public void PrintParkInformation(Park park)
        {
            Console.WriteLine(park.Name);
            Console.WriteLine($"Location: {park.Location.PadLeft(12)}");
            Console.WriteLine($"Established: {park.EstablishDate.ToString().PadLeft(25)}");
            Console.WriteLine($"Area: {park.Area.ToString().PadLeft(16)}");
            Console.WriteLine($"Annual Visitors: {park.Visitors.ToString()}");
            Console.WriteLine();
            Console.WriteLine(park.Description);
            Console.WriteLine();
        }
    }
}
