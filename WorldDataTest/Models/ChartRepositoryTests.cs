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
        private Mock<DbSet<ChartItem>> mockChartItems;
        private Mock<DbSet<City>> mockCity;
        private Mock<DbSet<Country>> mockCountry;
        private List<Chart> myCharts;
        private List<ChartItem> myChartItems;
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

            var data2 = myCharts.AsQueryable();

            mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.Provider).Returns(data.Provider);
           // mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
            mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.Expression).Returns(data.Expression);

            mockContext.Setup(m => m.ChartItems).Returns(mockChartItems.Object);
        }


        [TestInitialize]
        public void Initialize()
        {
            mockContext = new Mock<ChartContext>();
            mockCharts = new Mock<DbSet<Chart>>();
            mockCountry = new Mock<DbSet<Country>>();
            mockCity = new Mock<DbSet<City>>();
            mockChartItems = new Mock<DbSet<ChartItem>>();
            myCharts = new List<Chart>();
            myChartItems = new List<ChartItem>();
        }
        [TestCleanup]
        public void Cleanup()
        {
            mockContext = null;
            mockCharts = null;
            myCharts = null;
            mockCity = null;
            mockCountry = null;
            mockChartItems = null;
            myChartItems = null;
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
            
            Chart myChart = new Chart { ChartId = 1, Owner = owner };
            City myCity = new City { CityId = 1 };
            ChartItem newItem = new ChartItem { City = myCity };
            ChartItem newItem2 = new ChartItem { City = myCity };

            ConnectMocksToDataSource();

            //act
            var result = chartRepo.AddChartItem(1, newItem);
            var result2 = chartRepo.AddChartItem(1, newItem2);
            
            //assert
            Assert.IsTrue(result && result2);
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
