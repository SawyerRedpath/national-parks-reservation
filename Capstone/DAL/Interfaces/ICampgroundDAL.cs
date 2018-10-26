using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL.Interfaces
{
    public interface ICampgroundDAL
    {
        // All methods to be implemented by CampgroundDAL

        // Get campgrounds in a certain park
        IList<Campground> GetCampgrounds(int parkId);

        // Get all campgrounds (BONUS)
        //IList<Campground> GetCampgrounds()
    }
}
