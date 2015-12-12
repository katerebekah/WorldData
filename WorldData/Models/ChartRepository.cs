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
        //Get Country By Name (search)
        //Get All Cities By Country
        //Get City By Name (Search)
        //Get City By Id 
        
        //Get City Api URLS in Chart
        public List<string> GetApiUrlsInChart(int _chartId)
        {
            var query = from ch in context.ChartItems join ci in context.Cities on ch.City.CityId equals ci.CityId where ch.ChartId == _chartId select ci.ApiURL;
            List<string> result = query.ToList();
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