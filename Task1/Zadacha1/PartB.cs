using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    internal class PartB
    {
        public static LinkedList<int> Fibonacchi(int n)
        {
            var answer = new LinkedList<int>();
            //проверка, что пользователь выбрал число меньше одного
            if(n < 1)
            {
                return answer;
            }    
            
            answer.Add(0);
            //проверка, что пользователь выбрал число равное одному
            if(n == 1)
            {
                return answer;
            }
            
            answer.Add(1);
            // a и b первоначальные числа Фибоначчи
            int a = 0;
            int b = 1;

            //Цикл для создания чисел Фибоначчи с добавлением чисел в список по очереди.
            for(int i =1; i < n; i++)
            {
                int c = a + b;
                answer.Add(c);
                a = b;
                b = c;
            }
            return answer;  
        }
    }
}
