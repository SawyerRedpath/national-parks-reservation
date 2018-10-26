using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationDALTests : NationalParksDALTests
    {
        [TestMethod]
        public void AddReservation_AddsReservation()
        {
            // Arrange
            ReservationSqlDAL RSDal = new ReservationSqlDAL(ConnectionString);
            Reservation reservation = new Reservation();
            reservation.SiteId = 1;
            reservation.Name = "Test";
            reservation.FromDate = Convert.ToDateTime("10/22/2018");
            reservation.ToDate = Convert.ToDateTime("10/27/2018");


            // Act
            (bool added, int id) = RSDal.AddNewReservation(reservation);

            // Assert
            Assert.IsTrue(added);
            Assert.AreEqual(1, id);
        }
    }
}
