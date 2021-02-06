using System;
using System.IO;
using CommitWriter.API;

namespace CommitWriter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            void WriteData()
            {
                string path = Directory.GetCurrentDirectory() + "/data/commits.txt";
                try
                {
                    System.IO.File.WriteAllText(path, "testing");
                    Console.WriteLine("Successfully wrote commit history to commits.txt");
                }
                catch (Exception ex)
                {
                    // Not sure if this error handling is correct--how to test??
                    Console.WriteLine(ex);
                }
            }

            APIInit.InitializeClient();
            WriteData();
            //APICalls.GetCommits();
        }

    }
}
