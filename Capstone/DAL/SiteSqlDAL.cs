using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public class SiteSqlDAL : ISiteDAL
    {
        // Gets a list of sites that are available for reservation
        public IList<Site> GetSites(int campgroundId, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
    }
}
