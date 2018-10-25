using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class ParkCampgroundsCLI
    {
        private List<Campground> campgrounds = new List<Campground>();

        public ParkCampgroundsCLI(List<Campground> campgrounds)
        {
            this.campgrounds = campgrounds;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("Park Campgrounds");
                PrintCampgroundsInformation(campgrounds);



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

        private void PrintCampgroundsInformation(List<Campground> campgrounds)
        {
            List<string> months = new List<string>();
            months.Add("January");
            months.Add("February");
            months.Add("March");
            months.Add("April");
            months.Add("May");
            months.Add("June");
            months.Add("July");
            months.Add("August");
            months.Add("September");
            months.Add("October");
            months.Add("November");
            months.Add("December");

            string name = "Name";
            string open = "Open";
            string close = "Close";
            string dailyFee = "Daily Fee";

            Console.WriteLine($"{name.PadLeft(6)}{open.PadLeft(20)}{close.PadLeft(15)}{dailyFee.PadLeft(15)}");

            for (int i = 0; i < campgrounds.Count; i++)
            {
                Campground campground = campgrounds[i];
                string openMonth = months[campground.OpenFrom - 1];
                string closeMonth = months[campground.OpenTo -1];

                Console.WriteLine($"#{campground.CampgroundId.ToString().PadRight(5)}{campground.Name.PadRight(20)}{openMonth.PadRight(15)}{closeMonth.PadRight(15)}${campground.DailyFee.ToString()}");
            }
        }
    }
}
