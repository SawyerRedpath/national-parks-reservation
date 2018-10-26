using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkDALTests : NationalParksDALTests
    {
        [TestMethod]
        public void GetParksTest_ReturnAllParks()
        {
            // Arrange
            ParkSqlDAL PSDal = new ParkSqlDAL(ConnectionString);

            // Act
            IList<Park> parks = PSDal.GetParks();

            // Assert
            Assert.AreEqual(1, parks.Count);
        }

        [TestMethod]
        public void GetPark_GetsPark()
        {
            // Arrange
            ParkSqlDAL PSDal = new ParkSqlDAL(ConnectionString);

            // Act
            Park park = PSDal.GetPark(1);

            // Assert
            Assert.AreEqual("Testpark", park.Name);
        }

        
    }
}