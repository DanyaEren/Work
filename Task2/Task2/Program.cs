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
                //Округление размера файла до сотых
                double size = Math.Round((double)file.Length / (1024 * 1024), 2);
                Console.WriteLine($"| Номер по списку {i + 1}| Полное имя файла {file.FullName}| Размер файла {size} MB|");
            }

            //Сохранение данных в файл
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Хотите ли вы сохранить данные о файлах? Введите ответ 'Да'/'Нет' ");

            //Запоминание ответа и перевод в нижний регистр
            string answer = Console.ReadLine().ToLower();

            if (answer.Equals("да"))
            {
                Console.WriteLine("Введите путь сохранения файла");
                string savePath = Console.ReadLine();
                SaveInfoFile(files, savePath);
            }
        }

        static void SaveInfoFile(FileInfo[] files, string savePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(savePath))
                {
                    writer.WriteLine("Список файлов по размеру файлов");

                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo file = files[i];
                        //Округление размера файла до сотых
                        double size = Math.Round((double)file.Length / (1024 * 1024), 2);
                        writer.WriteLine($"| Номер по списку {i + 1}| Полное имя файла {file.FullName}| Размер файла {size} MB|");
                    }
                }

                Console.WriteLine($"Файл сохранён по пути '{savePath}'");
            }
            catch 
            {
                Console.WriteLine("Ошибка сохранение файла.Хотите попробовать снова? Введите ответ 'Да'/'Нет'");
                string retry = Console.ReadLine().ToLower();
                if (retry.Equals("да"))
                {
                    Console.WriteLine("Введите путь сохранения файла");
                    savePath = Console.ReadLine();
                    SaveInfoFile(files, savePath);
                }
            }

        }
    }

}