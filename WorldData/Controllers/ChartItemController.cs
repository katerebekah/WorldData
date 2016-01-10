using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldData.Models;

namespace WorldData.Controllers
{
    public class ChartItemController : ApiController
    {
        ChartRepository chartRepo = new ChartRepository();
        // GET api/<controller>
        public IHttpActionResult Get(int chartId)
        {
            try
            {
                List<City> cities = chartRepo.GetCitiesInChart(chartId);
                var settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                return Json(cities, settings);
            } catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}