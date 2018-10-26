using Capstone.DAL;
using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class CampgroundReservationCLI
    {
        private IList<Campground> campgrounds;
        private int campgroundId;
        public CampgroundReservationCLI(IList<Campground> campgrounds)
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
                campgroundId = int.Parse(Console.ReadLine());
                Console.Write("What is the arrival date? (MM/DD/YYYY) ");
                string fromDate = Console.ReadLine();
                Console.Write("What is the departure date? (MM/DD/YYYY) ");
                string toDate = Console.ReadLine();

                GetSites(campgroundId, fromDate, toDate);

                Console.WriteLine();
                Console.WriteLine("What site should be reserved (enter 0 to cancel) ? ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    break;
                }

                Console.WriteLine("What name should the reservation be made under? ");
                string name = Console.ReadLine();

                Reservation reservation = new Reservation();
                reservation.SiteId = int.Parse(input);
                reservation.FromDate = Convert.ToDateTime(fromDate);
                reservation.ToDate = Convert.ToDateTime(toDate);
                reservation.Name = name;

                AddNewReservation(reservation);
                break;

                
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

        private void GetSites(int campgroundId, string fromDate, string toDate)
        {
            ISiteDAL sitedal = new SiteSqlDAL(DatabaseConnectionString.DatabaseString);
            IList<Site> sites = sitedal.GetSites(campgroundId, fromDate, toDate);
            string siteNum = "Site No.";
            string maxOccupancy = "Max Occup.";
            string accessible = "Accessible?";
            string rvLength = "RV Length";
            string utility = "Utility";
            string cost = "Cost";
            DateTime fromDateTime = DateTime.Parse(fromDate);
            DateTime toDateTime = DateTime.Parse(toDate);
            decimal numDaysStay = (decimal)(toDateTime - fromDateTime).TotalDays;

           

            Console.WriteLine($"{siteNum.PadRight(12)} {maxOccupancy.PadRight(13)} {accessible.PadRight(19)} {rvLength.PadRight(18)} {utility.PadRight(12)} {cost} ");
            for (int i = 0; i < sites.Count; i++)
            {
                if (sites[i].Accessible == 0)
                {
                    accessible = "No";
                }
                else
                {
                    accessible = "Yes";
                }

                if (sites[i].MaxRvLength == 0)
                {
                    rvLength = "N/A";
                }
                else
                {
                    rvLength = sites[i].MaxRvLength.ToString();
                }

                if (sites[i].Utilities == 1)
                {
                    utility = "Yes";
                }

                else
                {
                    utility = "N/A";
                }


                Console.WriteLine($"{sites[i].SiteNumber.ToString().PadRight(12)} {sites[i].MaxOccupancy.ToString().PadRight(14)}" +
                    $"{accessible.PadRight(19)} {rvLength.PadRight(18)} {utility.PadRight(12)} {String.Format("{0:C2}", campgrounds[campgroundId].DailyFee * numDaysStay)}");
            }
        }

        public void AddNewReservation(Reservation reservation)
        {
            IReservationDAL reservationdal = new ReservationSqlDAL(DatabaseConnectionString.DatabaseString);
            (bool worked, int reservationId) = reservationdal.AddNewReservation(reservation);
            if (worked == true)
            {
                Console.WriteLine($"The reservation has been made and the confirmation id is {reservationId}");
                
            }
        }
    }
}
