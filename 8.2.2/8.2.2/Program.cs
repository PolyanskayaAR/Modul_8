using System;
using System.IO;

namespace _8._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                var rootDir = drive.RootDirectory;
                var files = rootDir.GetFiles();
                var folders = rootDir.GetDirectories();
                Console.WriteLine($"На диске {drive.Name} расположено:{Environment.NewLine}\t{files.Length} файлов{Environment.NewLine}\t{folders.Length} директорий");
            }
            xFilesIn();
            foreach (DriveInfo drive in drives)
            {
                var rootDir = drive.RootDirectory;
                var files = rootDir.GetFiles();
                var folders = rootDir.GetDirectories();
                Console.WriteLine($"На диске {drive.Name} расположено:{Environment.NewLine}\t{files.Length} файлов{Environment.NewLine}\t{folders.Length} директорий");
            }
            xFilesOut();

        }
        public static void xFilesIn()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    DirectoryInfo rootDir = new DirectoryInfo(string.Concat(drive.Name, @"xDir"));
                    if (!rootDir.Exists)
                    {
                        rootDir.Create();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void xFilesOut()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    DirectoryInfo rootDir = new DirectoryInfo(string.Concat(drive.Name, @"xDir"));
                    if (rootDir.Exists)
                    {
                        rootDir.Delete();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
