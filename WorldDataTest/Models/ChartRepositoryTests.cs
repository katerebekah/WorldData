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
        private Mock<DbSet<Chart>> mockChart;
        private List<ChartItem> myChart;

        private void ConnectMocksToDataSource()
        {
            // This setups the Mocks and connects to the Data Source (my_list in this case)
            var data = myChart.AsQueryable();

            mockChart.As<IQueryable<ChartItem>>().Setup(m => m.Provider).Returns(data.Provider);
            mockChart.As<IQueryable<ChartItem>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockChart.As<IQueryable<ChartItem>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockChart.As<IQueryable<ChartItem >>().Setup(m => m.Expression).Returns(data.Expression);

            mockContext.Setup(m => m.Charts).Returns(mockChart.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mockContext = new Mock<ChartContext>();
            mockChart = new Mock<DbSet<Chart>>();
            myChart = new List<ChartItem>();
        }
        [TestCleanup]
        public void Cleanup()
        {
            mockContext = null;
            mockChart = null;
            myChart = null;
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
        public void CanAddChartItemToChart()
        {
            ChartRepository chart = new ChartRepository(mockContext.Object);
            ChartItem newItem = new ChartItem { Priority = 1, mockChart.ChartId };
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
