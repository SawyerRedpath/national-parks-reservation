using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class CampgroundReservationCLI
    {
        private List<Campground> campgrounds;
        public CampgroundReservationCLI(List<Campground> campgrounds)
        {
            this.campgrounds = campgrounds;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("Search for Campground Reservation");
                PrintCampgroundReservationInformation(campgrounds);

                Console.WriteLine();
                Console.Write("Which campground (enter 0 to cancel)? ");
                int campgroundId = int.Parse(Console.ReadLine());
                Console.Write("What is the arrival date? ");
                DateTime fromDate = DateTime.Parse(Console.ReadLine());
                Console.Write("What is the departure date? ");
                DateTime toDate = DateTime.Parse(Console.ReadLine());

                // SearchForAvailableReservation()

                Console.ReadLine();
            }

            
        }
        private void PrintCampgroundReservationInformation(IList<Campground> campgrounds)
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
                string closeMonth = months[campground.OpenTo - 1];

                Console.WriteLine($"#{campground.CampgroundId.ToString().PadRight(5)}{campground.Name.PadRight(20)}{openMonth.PadRight(15)}{closeMonth.PadRight(15)}{String.Format("{0:C2}", campground.DailyFee)}");
            }
        }
    }
}
