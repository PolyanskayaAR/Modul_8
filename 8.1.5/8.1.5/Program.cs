using System;
using System.Collections.Generic;

namespace _8._1._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();
            NewFolder(Folders, "Dir1");
        }
        public static void NewFolder(Dictionary<string, Folder> DictDirs, string nameDir)
        {
            DictDirs.Add(nameDir, new Folder());
            Console.WriteLine($"made \"{nameDir}\" directory");
        }
    }
    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();

    }
}