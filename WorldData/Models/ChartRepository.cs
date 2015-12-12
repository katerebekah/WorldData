using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WorldData.Models
{
    public class ChartRespository
    {
        private ChartContext context;
        
        public ChartRespository()
        {
            context = new ChartContext();
        }

        public ChartRespository(ChartContext _context) 
        {
            context = _context;
        }

        //Get All Countries
        //Get Country By Name (search)
        //Get All Cities By Country
        //Get City By Name (Search)
        //Get City By Id 
        
        //Get City Api URLS in Chart

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
            }
            catch (ArgumentNullException)
            {
                result = false;
            }
            return result;
        }

        //Remove City from Chart
        //Update City Priority In Chart

    }
}