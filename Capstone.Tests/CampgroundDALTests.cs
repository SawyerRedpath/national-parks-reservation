using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundDALTests : NationalParksDALTests
    {
        [TestMethod]
        public void GetCampgrounds_GetsCampgrounds()
        {
            // Arrange
            CampgroundSqlDAL CSDal = new CampgroundSqlDAL(ConnectionString);

            // Act
            IList<Campground> campgrounds = CSDal.GetCampgrounds(1);

            // Assert
            Assert.AreEqual(1, campgrounds.Count);
        }
    }
}
