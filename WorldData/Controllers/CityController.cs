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
    public class CityController : ApiController
    {
        private ChartRepository chartRepo = new ChartRepository();

        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            try
            {
                List<Country> countries = chartRepo.GetAllCountries();
                var settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                return Json(countries, settings);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetCitiesInCountry(int cityId)
        {
            try
            {
                List<City> cities = chartRepo.GetAllCitiesInCountry(cityId);
                var settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                return Json(cities, settings);
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

    }
}
