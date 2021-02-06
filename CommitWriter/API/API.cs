using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CommitWriter.API
{
    //  This class is the starter for contacting an API
    public static class APIInit
    {
        public static HttpClient APIClient { get; set; }

        public static void InitializeClient()
        {
            APIClient = new HttpClient();
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("Connection initialized");
        }
    }

    public class APICalls
    {
        public async Task GetCommits()
        {
            string url = "https://api.bitbucket.org/2.0/repositories/calanceus/interviews17/commits";

            using (HttpResponseMessage response = await APIInit.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.Write(response);
                }
            };
        }
    }
}