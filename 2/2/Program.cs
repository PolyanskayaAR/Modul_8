using System;
using System.IO;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dirName = "";

            while (!Directory.Exists(dirName)) //Вводим имя директория, проверяем его существование
            {
                Console.WriteLine("Enter directory:");
                dirName = Console.ReadLine();
            }
            try
            {
                DirectoryInfo myDir = new DirectoryInfo(dirName);

                long totalSum;

                totalSum = Root_Total_Value(myDir, 0); //Вызываем Метод вычисления объема файлов

                Console.WriteLine($"Total volume {totalSum} bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thanks for the job");
            }


        }
        //

        static long Root_Total_Value(DirectoryInfo dir, long r_vol) //Метод вычисления объема файлов в условно корневом директории
        {
            long r_sum = r_vol;
            FileInfo[] r_fileArr = dir.GetFiles();
            for (int i = 0; i < r_fileArr.Length; i++)
            {
                Console.WriteLine("File " + r_fileArr[i].Name + " Volume " + r_fileArr[i].Length + " bytes");
                r_sum += r_fileArr[i].Length;
            }

            Console.WriteLine("Files of the directory - " + dir.FullName);
            Console.WriteLine("Volume - " + r_sum + " bytes");

            DirectoryInfo[] dirArr = dir.GetDirectories();
            r_sum += Total_Value(dirArr, r_sum); //Вызываем Метод вычесления объема файлов в поддиректориях

            return r_sum;
        }

        //
        static long Total_Value(DirectoryInfo[] workDir, long vol) //Метод вычесления объема файлов в поддиректориях
        {
            long sum = vol;

            for (int i = 0; i < workDir.Length; i++)
            {

                FileInfo[] fileArr = workDir[i].GetFiles();
                for (int j = 0; j < fileArr.Length; j++)
                {
                    Console.WriteLine("File " + fileArr[j].Name + " Volume " + fileArr[j].Length + " bytes");
                    sum += fileArr[j].Length;
                }
                Console.WriteLine("Files of the directory " + workDir[i].FullName);
                Console.WriteLine("Volume " + sum + " bytes");
                sum += Total_Value(workDir[i].GetDirectories(), sum); //Вызываем Метод вычесления объема файлов в поддиректориях
            }
            return sum;
        }

    }
}

