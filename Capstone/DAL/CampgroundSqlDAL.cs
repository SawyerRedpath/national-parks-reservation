using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public class CampgroundSqlDAL : ICampgroundDAL
    {
        public IList<Campground> GetCampgrounds(int parkId)
        {
            throw new NotImplementedException();
        }
    }
}
