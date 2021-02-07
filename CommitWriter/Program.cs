using System;
using System.IO;
using CommitWriter.API;
using CommitWriter.Writer;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CommitWriter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            APIInit.InitializeClient();
            APICaller.GrabCommits().Wait();
        }
    }

    public static class Go
    {
        public static void DataWriter()
        {
            {
                string path = Directory.GetParent("data").FullName;
                Console.WriteLine(path);
                try
                {
                    // System.IO.File.WriteAllText(path, "testing");
                    Console.WriteLine("Successfully wrote commit history to commits.txt");
                }
                catch (Exception ex)
                {
                    // Not sure if this error handling is correct--how to test??
                    Console.WriteLine(ex);
                }
            }
        }

        public static void DataFormatter(dynamic items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.message);
                Console.WriteLine(item.date);
            }
        }

    }

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
                    CommitModel items = await response.Content.ReadAsAsync<CommitModel>();
                    Go.DataFormatter(items.Values);
                    return items;
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


