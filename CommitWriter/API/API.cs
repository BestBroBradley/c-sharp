using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CommitWriter.API
{
    class APIInit
    {
        HttpClient client = new HttpClient();

        public static async Task QueryAPI()
        {
            APIInit apiinit = new APIInit();
            Console.WriteLine("Querying API.");
            await apiinit.GetData();
        }

        private async Task GetData()
        {
            string response = await client.GetStringAsync("https://api.bitbucket.org/2.0/repositories/calanceus/interviews17/commits");
            Console.WriteLine("Received data.");
            Console.WriteLine(response);
        }

    }
}