using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WorldData.Services
{
    public class DataService
    {
        string ApiURL = "https://www.quandl.com/data/";
        string ApiKey = "?api_key=mWbezmtRyiryCF8GP5sN";
        string ApiDatabase = "UGID";
        public async void getSomething()
        {
            string response = await GetResource();
        }
        //Get all data options
        public IEnumerable<string> getAllCountries()
        {
            return new List<string>();
        }

        public IEnumerable<string> getAllDataItems()
        {

            return new List<string>();
        }

        //Get data for specific query

        public string getData(string countryCode, string dataItem)
        {

            return "";
        }

        async Task<string> GetResource()
        {
            using (var client = new HttpClient())
            {
                // Set up the client to send/receive requests
                client.BaseAddress = new Uri(ApiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Send/receive a response
                return await client.GetStringAsync(ApiDatabase + ApiKey);
            }
        }
    }
}