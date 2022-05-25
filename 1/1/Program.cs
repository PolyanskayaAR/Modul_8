using System;
using System.IO;

namespace _1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter a directory to succeed:"); //Вводим путь директория
            string DirPath = Console.ReadLine();
            DirectoryInfo myDir = new DirectoryInfo(DirPath);

            try
            {
                DirectoryInfo[] diArr = myDir.GetDirectories(); // Получаем вложенные директории
                FileInfo[] fiArr = myDir.GetFiles(); // Получаем файлы в директории
                DirDel(diArr); //Вызываем метод удаления директориев
                FileDel(fiArr); //Вызываем метод удаления файлов
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter error"); //Вывод сообщения о некорректном вводе
                Console.WriteLine(ex.ToString()); //Детализация
            }
            finally
            {
                Console.WriteLine("Thanks for the job");
            }
        }

        static void DirDel(DirectoryInfo[] vs) //Метод удаления директориев
        {
            double duration;

            for (int i = 0; i < vs.Length; i++) //Проходим по списку директориев
            {
                duration = (DateTime.Now - vs[i].LastAccessTime).TotalMinutes; //Получаем время последнего доступа (использования) директория
                if (duration > 30)                                             //Если прошло больше 30 мин - удаляем
                {
                    Console.WriteLine($"{vs[i].Name} Directory deleting");
                    vs[i].Delete(true);
                }
            }
        }
        static void FileDel(FileInfo[] fl)  //Метод удаления файлов
        {
            double duration;
            for (int i = 0; i < fl.Length; i++)  //Проходим по списку файлов
            {
                duration = (DateTime.Now - fl[i].LastAccessTime).TotalMinutes; //Получаем время последнего доступа (использования) файла
                if (duration > 30)                                             //Если прошло больше 30 мин - удаляем
                {
                    Console.WriteLine($"{fl[i].Name} File deleting");
                    fl[i].Delete();
                }
            }
        }

    }