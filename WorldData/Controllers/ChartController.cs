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

namespace WorldData.Controllers
{
    public class ChartController : ApiController
    {
        private ChartRepository chartRepo = new ChartRepository();
        private DataService dataService = new DataService();


        //api/chart/ownerId
        [Authorize]
        public IHttpActionResult Get(string ownerId)
        {
            int chartId = chartRepo.GetUserChart(ownerId);
            return Ok(chartId);
        }
        
        //Add new item to Chart
        //Rearrange chart item
        //Delete Chart Item
        public IHttpActionResult Delete(int chartId, int itemId)
        {
            chartRepo.RemoveChartItem(chartId, itemId);
            return Ok();
        }
        //get all countries
        public IHttpActionResult GetCountries()
        {
            List<Country> countries = chartRepo.GetAllCountries();
            string jsonCountries = JsonConvert.SerializeObject(countries);
            return Ok(jsonCountries);
        }
        //get all cities in country
        public IHttpActionResult GetCitiesInCountry(int cityId)
        {
            List<City> cities = chartRepo.GetAllCitiesInCountry(cityId);
            
            return Ok(cities);
        }
    }
}