using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CommitWriter.API
{
    class APIInit
    {
        public static async Task<CommitModel> QueryAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.bitbucket.org/2.0/repositories/calanceus/interviews17/commits");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Querying API");

                HttpResponseMessage response = await client.GetAsync("https://api.bitbucket.org/2.0/repositories/calanceus/interviews17/commits");
                Console.Write(response.data);
                if (response.IsSuccessStatusCode)
                {
                    CommitModel commits = await response.Content.ReadAsAsync<CommitModel>();
                    Console.WriteLine("We got the goods.");
                    return commits;
                }
                else
                {
                    Console.WriteLine("Hit the else.");
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
    }
}