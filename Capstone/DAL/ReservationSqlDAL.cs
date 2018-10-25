using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public class ReservationSqlDAL : IReservationDAL
    {
        // Is this neccesary? not sure
        public IList<Reservation> GetReservations()
        {
            throw new NotImplementedException();
        }
    }
}
