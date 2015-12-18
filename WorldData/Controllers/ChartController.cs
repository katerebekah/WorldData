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

namespace WorldData.Controllers
{
    public class ChartController : ApiController
    {
        private ChartRepository chartRepo = new ChartRepository();
        private DataService dataService = new DataService();

        [Authorize]
        public IHttpActionResult GetChart()
        {
            return Ok();
        }
        //Get Chart for User
        //Get/Create Chart for new user
        //Add new item to Chart
        //Rearrange chart item
        //Delete Chart Item

        //get all countries
        //get all cities in country
    }
}