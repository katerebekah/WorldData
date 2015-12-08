using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldData.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace WorldDataTest
{
    [TestClass]
    public class ChartRepositoryTests
    {
        private Mock<ChartContext> mockContext;
        private ApplicationUser owner;

        private void ConnectMocksToDataSource()
        {

        }

        //Get Methods for City and Country
        [TestMethod]
        public void CanGetAllCountries()
        {
        }

        [TestMethod]
        public void CanGetAllCities()
        {

        }

        [TestMethod]
        public void CanGetCityById()
        {

        }

        [TestMethod]
        public void CanGetCountryById()
        {

        }

        [TestMethod]
        public void CanGetCitiesByCountry()
        {

        }

        [TestMethod]
        public void CanGetCityByName()
        {

        }

        [TestMethod]
        public void CanGetCountryByName()
        {

        }

        //CRUD methods for chart

        [TestMethod]
        public void CanAddCityToChart()
        {

        }

        [TestMethod]
        public void CanRemoveCityFromChart()
        {

        }

        [TestMethod]
        public void CanUpdateCityPriorityInChart()
        {

        }

        [TestMethod]
        public void CanGetAllCitiesInChart()
        {

        }

        //Misc
        [TestMethod]
        public void CanCreateChart()
        {

        }
    }
}
