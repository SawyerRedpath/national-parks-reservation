using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL.Interfaces
{
    public interface IReservationDAL
    {
        // All methods to be implemented by ReservationDAL

        // Adds a reservation
        (bool,int) AddNewReservation(Reservation reservation);



    }
}
