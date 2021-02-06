using System;
using CommitWriter.API;

namespace CommitWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            APICalls.GetCommits();
        }
    }
}
