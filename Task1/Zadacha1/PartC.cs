using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    internal class PartC
    {
        //Консольное приложение для вывода чисел Фибоначчи
        class Program
        {
            static void Main()
            {
                Console.WriteLine("Введите количество цифр Фибоначчи(Число n)");
                int n = int.Parse(Console.ReadLine());
                //Вызов метода для подсчёта чисел Фибоначчи
                var result = PartB.Fibonacchi(n);

                Console.WriteLine("Числа Фибоначчи");
                //Вывод чисел Фибоначчи по списку и их вывод
                foreach (var item in result) Console.WriteLine(item + " ");

                Console.ReadKey();
            }
           
        }
    }
}
