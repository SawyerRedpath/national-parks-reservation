using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class SiteDALTests : NationalParksDALTests
    {
        [TestMethod]
        public void GetSites_GetsSites()
        {
            // Arrange
            SiteSqlDAL SSDal = new SiteSqlDAL(ConnectionString);
            IList<Site> sites = new List<Site>();

            // Act
            sites = SSDal.GetSites(1, "10/20/2018", "10/25/2018");

            // Assert
            Assert.AreEqual(1, sites.Count);
        }
    }
}
