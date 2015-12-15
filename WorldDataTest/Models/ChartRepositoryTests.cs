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
        private List<City> myCities;
        private List<Country> myCountries;
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

            var data2 = myChartItems.AsQueryable();

            mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.Provider).Returns(data2.Provider);
            mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.GetEnumerator()).Returns(data2.GetEnumerator());
            mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.ElementType).Returns(data2.ElementType);
            mockChartItems.As<IQueryable<ChartItem>>().Setup(m => m.Expression).Returns(data2.Expression);

            mockContext.Setup(m => m.ChartItems).Returns(mockChartItems.Object);

            var data3 = myCities.AsQueryable();

            mockCity.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data3.Provider);
            mockCity.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(data3.GetEnumerator());
            mockCity.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data3.ElementType);
            mockCity.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data3.Expression);

            mockContext.Setup(m => m.Cities).Returns(mockCity.Object);

            var data4 = myCountries.AsQueryable();

            mockCountry.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data4.Provider);
            mockCountry.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(data4.GetEnumerator());
            mockCountry.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data4.ElementType);
            mockCountry.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data4.Expression);

            mockContext.Setup(m => m.Countries).Returns(mockCountry.Object);
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
            myCountries = new List<Country>();
            myCities = new List<City>();
            owner = new ApplicationUser();
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
            myCities = null;
            myCountries = null;
        }

        //Get Methods for City and Country
        [TestMethod]
        public void CanGetAllCountries()
        {
            //arrange
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);
            Country Usa = new Country { CountryId = 1, Name = "USA" };
            Country Mexico = new Country { CountryId = 2, Name = "Mexico" };

            myCountries.Add(Usa);
            myCountries.Add(Mexico);
            //act
            ConnectMocksToDataSource();
            List<Country> Actual = chartRepo.GetAllCountries();
            //assert
            Assert.AreEqual(Actual.Count(), 2);
        }

        [TestMethod]
        public void CanGetCitiesByCountry()
        {
            //arrange
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);
            City NewYork = new City { CityId = 1, CountryId = 1, Name = "NewYork" };
            City Tokyo = new City { CityId = 2, CountryId = 2, Name = "Tokyo" };

            myCities.Add(NewYork);
            myCities.Add(Tokyo);
            //act
            ConnectMocksToDataSource();
            List<City> Actual = chartRepo.GetAllCitiesInCountry(1);
            //assert
            Assert.AreEqual(Actual.Count(), 1);
        }

        [TestMethod]
        public void CanGetCityById()
        {

            //arrange
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);
            City NewYork = new City { CityId = 1, CountryId = 1, Name = "NewYork" };
            City Tokyo = new City { CityId = 2, CountryId = 2, Name = "Tokyo" };

            myCities.Add(NewYork);
            myCities.Add(Tokyo);
            //act
            ConnectMocksToDataSource();
            City Actual = chartRepo.GetCityById(1);
            //assert
            Assert.AreEqual(Actual.CityId, 1);
            Assert.AreEqual(Actual.Name, "NewYork");
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

            myCharts.Add(myChart);

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
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);

            Chart myChart = new Chart { ChartId = 1, Owner = owner };
            City myCity = new City { CityId = 1 };
            ChartItem newItem = new ChartItem { City = myCity };
            ChartItem newItem2 = new ChartItem { City = myCity };

            myCharts.Add(myChart);

            ConnectMocksToDataSource();

            var result = chartRepo.AddChartItem(1, newItem);
            var result2 = chartRepo.AddChartItem(1, newItem2);

            //act
            var result3 = chartRepo.RemoveChartItem(1, newItem);

            //assert
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void CanUpdateCityPriorityInChart()
        {

            //arrange
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);

            Chart myChart = new Chart { ChartId = 1, Owner = owner };
            City myCity = new City { CityId = 1 };
            City myCity2 = new City { CityId = 2 };
            City myCity3 = new City { CityId = 3 };
            ChartItem newItem = new ChartItem { City = myCity };
            ChartItem newItem2 = new ChartItem { City = myCity2 };
            ChartItem newItem3 = new ChartItem { City = myCity3 };

            myCharts.Add(myChart);

            ConnectMocksToDataSource();

            var result = chartRepo.AddChartItem(1, newItem);
            var result2 = chartRepo.AddChartItem(1, newItem2);
            var result3 = chartRepo.AddChartItem(1, newItem3);

            //act
            var result4 = chartRepo.RearrangeChartItems(1, newItem2, 0);

            //assert
            Assert.IsTrue(result4);
            Assert.AreEqual(myChart.ChartItems[0].City.CityId, newItem2.City.CityId);
            Assert.AreEqual(myChart.ChartItems[1].City.CityId, newItem.City.CityId);
            Assert.AreEqual(myChart.ChartItems[2].City.CityId, newItem3.City.CityId);

        }

        [TestMethod]
        public void CanGetAllAPIURLSInChart()
        {
            //arrange
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);

            Chart myChart = new Chart { ChartId = 1, Owner = owner };
            City myCity = new City { CityId = 1, ApiURL = "Hello" };
            City myCity2 = new City { CityId = 2, ApiURL = "My Name" };
            City myCity3 = new City { CityId = 3, ApiURL = "Is Kate" };
            ChartItem newItem = new ChartItem { City = myCity, ChartId =1 };
            ChartItem newItem2 = new ChartItem { City = myCity2, ChartId = 1 };
            ChartItem newItem3 = new ChartItem { City = myCity3, ChartId = 1 };

            myCharts.Add(myChart);
            myCities.Add(myCity);
            myCities.Add(myCity2);
            myCities.Add(myCity3);
            myChartItems.Add(newItem);
            myChartItems.Add(newItem2);
            myChartItems.Add(newItem3);
            
            ConnectMocksToDataSource();
            
            //act
            List<string> ApiUrls = chartRepo.GetApiUrlsInChart(1);


            //assert
            Assert.AreEqual(ApiUrls.Count, 3);
            Assert.AreEqual(ApiUrls[1], "My Name");
            Assert.AreEqual(ApiUrls[2], "Is Kate");
        }

        //Misc
        [TestMethod]
        public void CanCreateChart()
        {
            //arrange
            ChartRepository chartRepo = new ChartRepository(mockContext.Object);
            ConnectMocksToDataSource();
            //act
            var result = chartRepo.AddChartToNewProfile(owner);

            //assert
            Assert.IsTrue(result);
        }
    }
}
