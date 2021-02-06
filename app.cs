using System;
using System.IO;

class CommitWriter
{
    static void Main(string[] args)
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
}