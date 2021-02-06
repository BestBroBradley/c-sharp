using System;
using System.IO;

class Writer
{
    static void Main(string[] args)
    {
        string path = Directory.GetCurrentDirectory() + "/data/commits.txt";
        System.IO.File.WriteAllText(path, "testing");
    }
}