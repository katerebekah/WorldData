using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace WorldData.Models
{
    public class ChartRepository
    {
        private ChartContext context;
        
        public ChartRepository()
        {
            context = new ChartContext();
        }

        public ChartRepository(ChartContext _context) 
        {
            context = _context;
        }

        //Get All Countries
        public List<Country> GetAllCountries()
        {
            var result = new List<Country>();
            var query = from c in context.Countries select c;
            result = query.ToList();
            return result;
        }

        //Get All Cities By Country
        public List<City> GetAllCitiesInCountry (int countryId)
        {
            var result = new List<City>();
            var query = from c in context.Cities where c.CountryId == countryId select c;
            result = query.ToList();
            return result;
        }
        
        public City GetCityById (int cityId)
        {
            City result = null;
            var query = from c in context.Cities where c.CityId == cityId select c;
            result = query.Single<City>();
            return result;
        }
        
        //Get City Api URLS in Chart
        public List<string> GetApiUrlsInChart(int _chartId)
        {
            var query = from c in context.ChartItems where c.ChartId == _chartId select c.City.ApiURL;
            List < string > result = query.ToList();
            return result ;
        }

        public List<City> GetCitiesInChart(int _chartId)
        {
            var query = from c in context.ChartItems where c.ChartId == _chartId select c.City;
            List<City> result = query.ToList();
            return result;
        }

        //Get Chart ID from user
        public int GetUserChart(string ownerId)
        {
            var query = from c in context.Charts where c.OwnerId == ownerId select c;
            Chart chart = query.Single<Chart>();
            int result = chart.ChartId;
            return result;
        }
        
        //Add Chart to New Profile
        public int AddChartToNewProfile(string ownerId)
        {
            var chart = new Chart { OwnerId = ownerId, ChartItems = new List<ChartItem>() };
            context.Charts.Add(chart);
            context.SaveChanges();
            return chart.ChartId;
        }

        //Add City to Chart
        public bool AddChartItem(int _chartId, ChartItem _chart)
        {
            bool result = true;
            var query = from c in context.Charts where c.ChartId == _chartId select c;
            Chart foundChart = null;
            try
            {
                foundChart = query.Single<Chart>();
                context.ChartItems.Add(_chart);
                foundChart.ChartItems.Add(_chart);
                context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                result = false;
            }
            return result;
        }

        public bool AddChartItem(int _chartId, City city)
        {
            ChartItem _chartItem = new ChartItem {City = city, ChartId = _chartId};
            return AddChartItem(_chartId, _chartItem);
        }

        public bool AddChartItem(int _chartId, int _cityId)
        {
            City cityToAdd = GetCityById(_cityId);
            return AddChartItem(_chartId, cityToAdd);
        }

        //Remove City from Chart
        public bool RemoveChartItem(int _chartId, int _itemIdToRemove)
        {
            var query = from ch in context.ChartItems where ch.City.CityId == _itemIdToRemove && ch.ChartId == _chartId select ch;
            var chartItem = query.Single<ChartItem>();
            return RemoveChartItem(_chartId, chartItem);
        }

        public bool RemoveChartItem(int _chartId, ChartItem _itemToRemove)
        {
            bool result = true;
            var query = from c in context.Charts where c.ChartId == _chartId select c;
            Chart foundChart = null;
            try
            {
                foundChart = query.Single<Chart>();
                foundChart.ChartItems.Remove(_itemToRemove);
                context.ChartItems.Remove(_itemToRemove);
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                result = false;
                throw;
            }
            catch (ArgumentNullException)
            {
                result = false;
                throw;
            }
            return result;
        }
        //Update City Priority In Chart
        public bool RearrangeChartItems(int _chartId, int _itemIdToMove, int _newPosition)
        {
            var query = from c in context.ChartItems where c.City.CityId == _itemIdToMove select c;
            var foundChartItem = query.Single<ChartItem>();
            return RearrangeChartItems(_chartId, foundChartItem, _newPosition);
        }

        //Update City Priority In Chart
        public bool RearrangeChartItems(int _chartId, ChartItem _itemToMove, int _newPosition)
        {
            bool result = true;
            var query = from c in context.Charts where c.ChartId == _chartId select c;
            Chart foundChart = null;
            try
            {
                foundChart = query.Single<Chart>();
                foundChart.ChartItems.Remove(_itemToMove);
                foundChart.ChartItems.Insert(_newPosition, _itemToMove);
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                result = false;
                throw;
            }
            catch (ArgumentNullException)
            {
                result = false;
                throw;
            }
            return result;
        }

    }
}