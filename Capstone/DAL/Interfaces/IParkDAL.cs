using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL.Interfaces
{
    public interface IParkDAL
    {
        // All methods to be implemented by ParkDAL

        // Gets all available parks in alphabetical order
        IList<Park> GetParks();

        // Gets all parks with a certain id
        Park GetPark(int parkId);
    }
}
