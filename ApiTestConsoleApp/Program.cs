using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "";
            Console.WriteLine("This mini program is testing the api in C#");
            Task.Run(async () =>
            {
                var asynctester = new AsyncTester();
                hello = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await asynctester.ApiCaller());
                Console.WriteLine(hello);
            }).Wait();
            Console.WriteLine(hello);

        }

    }
    class AsyncTester
    {
        string ApiURL = "";
        string ApiKey = "?api_key=mWbezmtRyiryCF8GP5sN";
        string ApiDatabase = "UGID";

        public async Task<string> ApiCaller()
        {
            using (var client = new HttpClient())
            {
                // Set up the client to send/receive requests
                //client.BaseAddress = new Uri(ApiURL);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Send/receive a response
                return await client.GetStringAsync("https://www.quandl.com/api/v3/datasets/WIKI/FB.json");
            }

        }
    }
}
