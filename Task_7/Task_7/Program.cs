using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    class Program
    {
        static int n;
        static int k;
        static int[] numbers = new int[100];

        static bool[] usedNumbers = new bool[100];
        static int[] tmpPlacement = new int[100];
        static int curPointer = 0;

        static int numberOfPlacements = 0;

        static void rec(int numbersLeftToPlace)
        {
            if (numbersLeftToPlace == 0)
            {
                Console.Write("{0} размещение: ", numberOfPlacements + 1);
                for (int i = 0; i < k; i++)
                {
                    Console.Write(tmpPlacement[i] + " ");
                }
                Console.Write('\n');
                numberOfPlacements++;
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (!usedNumbers[i])
                {
                    usedNumbers[i] = true;
                    tmpPlacement[curPointer] = numbers[i];
                    curPointer++;
                    rec(numbersLeftToPlace - 1);
                    usedNumbers[i] = false;
                    curPointer--;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание № 7 \n Сгенерировать все размещения из N элементов по K без повторений и выписать их в лексикографическом порядке.");
            Console.Write("Введите число N: ");
            n = InputNatNumber();
            Console.Write("Введите число K: ");
            k = InputNatNumber();
            Console.WriteLine($"Введите числа исходного множества: ");           
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i+1} число = ");
                numbers[i] = InputNatNumber();
            }
            rec(k);
            Console.WriteLine("\nДля выхода нажмите клавишу Enter...");
            Console.ReadKey();
        }

        //Проверка введенного числа, натуральное ли оно
        public static int InputNatNumber()
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if ((!ok) || (n <= 0))
                    Console.WriteLine("Натуральное число введено неверно. Повторите ввод.");
            } while ((!ok) || (n <= 0));
            return n;
        }

    }
}

