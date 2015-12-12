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
        private Mock<DbSet<Chart>> mockCharts;
        private List<Chart> myCharts;
        private ApplicationUser owner;

        private void ConnectMocksToDataSource()
        {
            // This setups the Mocks and connects to the Data Source (my_list in this case)
            var data = myCharts.AsQueryable();

            mockCharts.As<IQueryable<Chart>>().Setup(m => m.Provider).Returns(data.Provider);
            mockCharts.As<IQueryable<Chart>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockCharts.As<IQueryable<Chart>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockCharts.As<IQueryable<Chart>>().Setup(m => m.Expression).Returns(data.Expression);

            mockContext.Setup(m => m.Charts).Returns(mockCharts.Object);
        }


        [TestInitialize]
        public void Initialize()
        {
            mockContext = new Mock<ChartContext>();
            mockCharts = new Mock<DbSet<Chart>>();
            myCharts = new List<Chart>();
        }
        [TestCleanup]
        public void Cleanup()
        {
            mockContext = null;
            mockCharts = null;
            myCharts = null;
        }

        //Get Methods for City and Country
        [TestMethod]
        public void CanGetAllCountries()
        {
            //arrange
        
            //act
            //assert
        }

        [TestMethod]
        public void CanGetAllCities()
        {

            //arrange
            //act
            //assert
        }

        [TestMethod]
        public void CanGetCityById()
        {

            //arrange
            //act
            //assert
        }
        
        [TestMethod]
        public void CanGetCitiesByCountry()
        {

            //arrange
            //act
            //assert
        }
        
        [TestMethod]
        public void CanAddChartItemToChart()
        {
            //arrange
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);
            List<ChartItem> chartItems = new List<ChartItem>();

            ChartItem newItem = new ChartItem();
            ChartItem newItem2 = new ChartItem();
            
            //act
            var result = chartRepo.AddChartItem(1, newItem);
            var result2 = chartRepo.AddChartItem(1, newItem2);
            
            //assert
            Assert.IsTrue(result == true && result2 == true);
        }

        [TestMethod]
        public void CanRemoveCityFromChart()
        {

            //arrange
            //act
            //assert
        }

        [TestMethod]
        public void CanUpdateCityPriorityInChart()
        {

            //arrange
            //act
            //assert
        }

        [TestMethod]
        public void CanGetAllCitiesInChart()
        {

            //arrange
            //act
            //assert
        }

        //Misc
        [TestMethod]
        public void CanCreateChart()
        {

            //arrange
            //act
            //assert
        }
    }
}
