using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using worldDataWeb.Services;

namespace worldDataWeb.Controllers
{
    public class ProfileController : Controller
    {
        ApiService apiService = new ApiService();

        [Authorize]
        // GET: Profile
        public async Task<ActionResult> Index()
        {
            ViewBag.chartId = await apiService.GetChartId();
            return View("Index");
        }

    }
}
