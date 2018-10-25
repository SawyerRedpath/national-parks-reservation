using Capstone.DAL;
using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class ViewParksCLI
    {
        public const string DatabaseConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPCampsite;Integrated Security=True";
        
        public void Display()
        {
            while (true)
            {

                PrintHeader();

                Console.WriteLine();
                Console.WriteLine("Select a Park for Further Details");
                GetParks();
                Console.WriteLine("Q) Quit");
                Console.WriteLine();

                Console.Write("What option do you want to select? ");
                string input = (Console.ReadLine());


                Console.Clear();

                switch (input.ToUpper())
                {
                    case "1":
                    case "2":
                    case "3":
                        int numInput = int.Parse(input);
                        Park park = GetPark(numInput);
                        ParkInformationCLI PiCli = new ParkInformationCLI(park);
                        PiCli.Display();
                        break;


                    
                }

                Console.ReadLine();
                Console.Clear();
            }

        }

        private void PrintHeader()
        {
            Console.WriteLine(@"
 _   _         _    _                       _  ______               _    
| \ | |       | |  (_)                     | | | ___ \             | |   
|  \| |  __ _ | |_  _   ___   _ __    __ _ | | | |_/ /  __ _  _ __ | | __
| . ` | / _` || __|| | / _ \ | '_ \  / _` || | |  __/  / _` || '__|| |/ /
| |\  || (_| || |_ | || (_) || | | || (_| || | | |    | (_| || |   |   < 
\_| \_/ \__,_| \__||_| \___/ |_| |_| \__,_||_| \_|     \__,_||_|   |_|\_\
                                                                         
                                                                         
 _____                                _  _                               
/  __ \                              (_)| |                              
| /  \/  __ _  _ __ ___   _ __   ___  _ | |_   ___                       
| |     / _` || '_ ` _ \ | '_ \ / __|| || __| / _ \                      
| \__/\| (_| || | | | | || |_) |\__ \| || |_ |  __/                      
 \____/ \__,_||_| |_| |_|| .__/ |___/|_| \__| \___|                      
                         | |                                             
                         |_|                                             
______                                       _    _                      
| ___ \                                     | |  (_)                     
| |_/ /  ___  ___   ___  _ __ __   __  __ _ | |_  _   ___   _ __         
|    /  / _ \/ __| / _ \| '__|\ \ / / / _` || __|| | / _ \ | '_ \        
| |\ \ |  __/\__ \|  __/| |    \ V / | (_| || |_ | || (_) || | | |       
\_| \_| \___||___/ \___||_|     \_/   \__,_| \__||_| \___/ |_| |_|       
                                                                    ");
        }

        private void GetParks()
        {
            IParkDAL parkdal = new ParkSqlDAL(DatabaseConnectionString);
            IList<Park> parks = parkdal.GetParks();

            for (int i = 0; i < parks.Count; i++) 
            {
                Console.WriteLine($"{parks[i].ParkId}) {parks[i].Name}");
            }
        }

        // Gets a single parks information
        public Park GetPark(int parkId)
        {
            IParkDAL parkdal = new ParkSqlDAL(DatabaseConnectionString);
            Park park = parkdal.GetPark(parkId);
            return park;
        }

    }
}
