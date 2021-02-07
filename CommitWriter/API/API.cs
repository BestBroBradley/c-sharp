using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using CommitWriter.Writer;

namespace CommitWriter.API
{
    public static class APIInit
    {
        public static HttpClient APIClient { get; set; }

        public static void InitializeClient()
        {
            APIClient = new HttpClient();
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

    public static class APICaller
    {
        public static async Task<CommitModel> GrabCommits()
        {
            string url = "https://api.bitbucket.org/2.0/repositories/calanceus/interviews17/commits";

            using (HttpResponseMessage response = await APIInit.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    CommitModel data = await response.Content.ReadAsAsync<CommitModel>();
                    return data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }

    public class CommitModel
    {
        public object Values { get; set; }
    }
}