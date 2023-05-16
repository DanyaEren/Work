using System;
using System.IO;
using System.Linq;
namespace Task2
{
    class Program
    { 
        static void Main()
        {
            Console.WriteLine("Введите путь к папке");
            string path = Console.ReadLine();

            //Проверка, что такой путь действителен с помощью Directory.Exists
            if (Directory.Exists(path) == false)
            {
                Console.WriteLine($" '{path}' Такого пути нет в системе");
                return; 
            }
            //Запоминание информации о директории, с сортировкой по размеру файла, с преобразованием в массив
            FileInfo[] files = new DirectoryInfo(path).GetFiles("*.*", SearchOption.AllDirectories).OrderByDescending(f => f.Length).ToArray();
           
            Console.WriteLine("Вывод списка файлов");

            for(int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i];
                double size = file.Length / 1024 * 1024;
                Console.WriteLine($"{i + 1}. {file.FullName}, ({size:F2}) MB ");
            }
        }
    }

}