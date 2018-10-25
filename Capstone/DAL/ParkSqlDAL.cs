using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        public IList<Park> GetParks()
        {
            throw new NotImplementedException();
        }

        // 
        public IList<Park> GetParks(string name)
        {
            throw new NotImplementedException();
        }
    }
}
