using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №5 из книги Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.\n №692е");
            Console.WriteLine("Дана матрица. Получить самое большое число в определенной области");

            int n;
            do
            {
                CheckInt("Введите размерность матрицы: ", out n);
                if (n < 1 || n > 100) Console.WriteLine("Ошибка ввода! Размер матрицы должен быть целым числом > 1 и < 101\n");
            } while (n < 1 || n > 100);
            Random rand = new Random();
            int[,] mas = new int[n, n];
           
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = rand.Next(-10, 10);
                    Console.Write("{0,4}", mas[i, j]);
                }
                Console.WriteLine();
            }

            int max = mas[0,0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((j >= i) && (n - 1 >= i + j))
                        if (mas[i, j] > max) max = mas[i, j];
                }
            }
            Console.WriteLine($"\nМаксимальный элемент в заданной области равен {max}");
            Console.WriteLine("\nДля выхода нажмите клавишу Enter...");
            Console.ReadKey();

        }
        static void CheckInt(string message, out int res)
        {
            bool check; // отвечает за проверку типа переменной
            Console.Write(message);
            do
            {
                string prior = Console.ReadLine();
                check = int.TryParse(prior, out res);
                if (check == false) Console.WriteLine("Неправильный ввод, попробуйте ещё раз.");
            } while (check == false);
        } // Проверка входных данных на соответствие типу Int
    }
}
    