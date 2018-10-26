using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class ParkCampgroundsCLI
    {
        private IList<Campground> campgrounds = new List<Campground>();

        public ParkCampgroundsCLI(IList<Campground> campgrounds)
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
                Console.WriteLine("1) Search for Available Reservation");
                Console.WriteLine("2) Return to Previous Screen");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();
                // Search for available reservation
                if (input == "1")
                {
                    Console.WriteLine("Searching for available reservation...");
                    Console.Clear();
                    CampgroundReservationCLI CRCli = new CampgroundReservationCLI(campgrounds);
                    CRCli.Display();
                }
                // Return to previous screen
                else if (input == "2")
                {
                    Console.WriteLine("Returning to previous screen...");
                    break;
                }

                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
            }
        }

        private void PrintCampgroundsInformation(IList<Campground> campgrounds)
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

            Console.WriteLine();

            Console.WriteLine($"{name.PadLeft(10)}{open.PadLeft(20)}{close.PadLeft(16)}{dailyFee.PadLeft(19)}");

            for (int i = 0; i < campgrounds.Count; i++)
            {
                Campground campground = campgrounds[i];
                string openMonth = months[campground.OpenFrom - 1];
                string closeMonth = months[campground.OpenTo -1];

                Console.WriteLine($"#{campground.CampgroundId.ToString().PadRight(5)}{campground.Name.PadRight(20)}{openMonth.PadRight(15)}{closeMonth.PadRight(15)}{String.Format("{0:C2}", campground.DailyFee)}");
            }
        }
    }
}
