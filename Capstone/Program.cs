using Capstone.CLI;
using System;

namespace capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewParksCLI vpcli = new ViewParksCLI();
            vpcli.Display();
        }
    }
}
