using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL.Interfaces
{
    public interface ISiteDAL
    {
        // All methods to be implemented by SiteDAL

        // Gets sites that are available for a reservation
        IList<Site> GetSites(int campgroundId, string fromDate, string toDate);

    }
}
