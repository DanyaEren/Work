using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    internal class PartC
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine("Введите количество цифр Фибоначчи(Число n)");
                int n = int.Parse(Console.ReadLine());

                var result = PartB.Fibonacchi(n);

                Console.WriteLine("Числа Фибоначчи");
                foreach (var item in result) Console.WriteLine(item + " ");

                Console.ReadKey();
            }
           
        }
    }
}
