using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using WorldData.Models;
using WorldData.Services;
using Newtonsoft.Json;
using System.Web.Routing;

namespace WorldData.Controllers
{
    public class ChartController : ApiController
    {
        private ChartRepository chartRepo = new ChartRepository();
        private DataService dataService = new DataService();


        //api/chart/ownerId
        [HttpGet]
        public IHttpActionResult Get(string Id)
        {
            try
            {
                int chartId = chartRepo.GetUserChart(Id);
                return Ok(chartId);
            }
            catch (Exception e)
            {
                int chartId = chartRepo.AddChartToNewProfile(Id);
                return Ok(chartId);
            }
        }
        
        [HttpDelete]
        public IHttpActionResult Delete(int chartId, int itemId)
        {
            chartRepo.RemoveChartItem(chartId, itemId);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Add(int chartId, int cityId)
        {
            chartRepo.AddChartItem(chartId, cityId);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Reorder (int chartId, int chartItemId, int newPosition)
        {
            try
            {
                chartRepo.RearrangeChartItems(chartId, chartItemId, newPosition);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

       
        
    }
}