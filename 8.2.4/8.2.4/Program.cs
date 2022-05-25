using System;
using System.IO;

namespace _8._2._4_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                DirectoryInfo testDir = new DirectoryInfo(@"C:\Users\Asya150203\Desktop\testFolder");
                if (testDir.Exists)
                {
                    testDir.MoveTo(@"C:\$Recycle.bin\testFolder");
                    //   testDir.MoveTo(@"C:\Users\Asya150203\.Trash\testFolder");
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
    }
}
