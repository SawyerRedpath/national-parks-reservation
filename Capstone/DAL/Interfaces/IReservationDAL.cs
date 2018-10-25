using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL.Interfaces
{
    public interface IReservationDAL
    {
        // All methods to be implemented by ReservationDAL

        // Gets available reservations for a certain campground
        IList<Reservation> GetReservations();
    }
}
