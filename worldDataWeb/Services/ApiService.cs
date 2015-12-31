using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using worldDataWeb.Models;

namespace worldDataWeb.Services
{
    public class ApiService
    {
        string ApiURL = "https://www.quandl.com/api/v3/datasets/";
        string ApiKey = "?api_key=mWbezmtRyiryCF8GP5sN";
        string ApiDatabase = "CITYPOP";
        string result;
        HttpClient httpClient;
        string ownerId;

        Uri ApiBaseURL = new Uri("http://localhost:61643/");

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> GetChartId()
        {
            ownerId = HttpContext.Current.User.Identity.GetUserId();
            httpClient.BaseAddress = ApiBaseURL;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // New code:
            HttpResponseMessage response = await httpClient.GetAsync(String.Format("api/chart/{0}", ownerId));
            if (response.IsSuccessStatusCode)
            {
                 return await response.Content.ReadAsStringAsync();
            } else
            {
                return response.StatusCode.ToString();
            }
        }

    }
}