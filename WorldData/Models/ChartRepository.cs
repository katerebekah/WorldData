using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
        
        //Get City Api URLS in Chart
        public List<string> GetApiUrlsInChart(int _chartId)
        {
            var query = from ch in context.ChartItems join ci in context.Cities on ch.City.CityId equals ci.CityId where ch.ChartId == _chartId select ci.ApiURL;
            List<string> result = query.ToList();
            return result;
        }

        //Add Chart to New Profile
        public bool AddChartToNewProfile(ApplicationUser owner)
        {
            var result = true;
            context.Charts.Add(new Chart { Owner = owner, ChartItems = new List<ChartItem>() });
            return result;
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
                foundChart.ChartItems.Add(_chart);
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

        public bool AddChartItem(int _chartId, City city)
        {
            ChartItem _chartItem = new ChartItem {City = city,  };
            
            AddChartItem(_chartId, _chartItem);
        }


        //Remove City from Chart
        public bool RemoveChartItem(int _chartId, ChartItem _itemToRemove)
        {
            bool result = true;
            var query = from c in context.Charts where c.ChartId == _chartId select c;
            Chart foundChart = null;
            try
            {
                foundChart = query.Single<Chart>();
                foundChart.ChartItems.Remove(_itemToRemove);
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