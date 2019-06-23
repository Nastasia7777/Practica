using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание № 12 \n Выполнить сравнение двух предложенных методов сортировки одномерных массивов, содержащих n элементов, по количеству пересылок и сравнений.");
            int[] arr = new int[] { 56, 3, 0, -4, 85, 7, 10, 1, 1, 5, 14, 16, -30 };
            double[] arr2 = new double[] { 56, 3, 0, -4, 85, 7, 10, 1, 1, 5, 14, 16, -30 };
            Console.WriteLine("Блочная сортировка:");
            BSort(arr);
            Console.WriteLine();
            Console.WriteLine("Пирамидальная сортировка:");
            PSort(arr2);
            Console.WriteLine("\nДля выхода нажмите клавишу Enter...");
            Console.ReadKey();
        }

        public static int countChange = 0;
        public static int countCompare = 0;

        static void BSort(int[] arr)
        {
            // сортировка неупорядоченного массива
            Console.WriteLine("Несортированный массив: \n" + String.Join(", ", arr));
            countChange = 0;                                    // обнуление счетчиков операций
            countCompare = 0;                                   // и времени
            int[] sortArr = BucketSort(arr);
            Console.WriteLine("\nОтсортированный неупорядоченный массив: \n" + String.Join(", ", sortArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
               countCompare, countChange);

            // сортировка упорядоченного по возрастанию массива
            countChange = 0;                                    // обнуление счетчиков операций
            countCompare = 0;                                   // и времени
            int[] sortSortedUpArr = BucketSort(sortArr);
            Console.WriteLine("\nОтсортированный упорядоченный по возрастанию массив: \n" + String.Join(", ", sortSortedUpArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
               countCompare, countChange);

            Array.Reverse(sortArr);
            countChange = 0;                                    // обнуление счетчиков операций
            countCompare = 0;                                   // и времени
            int[] sortSortedDownArr = BucketSort(sortArr);
            Console.WriteLine("\nОтсортированный упорядоченный по убыванию массив: \n" + String.Join(", ", sortSortedDownArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
              countCompare, countChange);
        }

        static int[] BucketSort(int[] arr)
        {
            countChange = 0;                                    // обнуление счетчиков операций
            countCompare = 0;

            // Предварительная проверка элементов исходного массива
            if (arr == null || arr.Length < 2)
            {
                countCompare++;
                return arr;
            }

            // Поиск элементов с максимальным и минимальным значениями
            int maxValue = arr[0];
            int minValue = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                    countCompare++;
                }

                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                    countCompare++;
                }
            }

            // Создание временного массива "карманов" в количестве,
            // достаточном для хранения всех возможных элементов,
            // чьи значения лежат в диапазоне между minValue и maxValue.
            // Т.е. для каждого элемента массива выделяется "карман" List<int>.
            // При заполнении данных "карманов" элементы исходного не отсортированного массива
            // будут размещаться в порядке возрастания собственных значений "слева направо".

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            // Занесение значений в пакеты

            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i] - minValue].Add(arr[i]);
            }

            // Восстановление элементов в исходный массив
            // из карманов в порядке возрастания значений

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        arr[position] = bucket[i][j];
                        position++;
                        countChange++;
                    }
                }
            }
            return arr;
        }

        static void PSort(double[] arr)
        {
            // сортировка неупорядоченного массива
            Console.WriteLine("Несортированный массив: " + String.Join(", ", arr));
            countChange = 0;
            countCompare = 0;
            double[] sortArr = PiromidSort(arr, arr.Length);
            Console.WriteLine("\nОтсортированный неупорядоченный массив: \n" + String.Join(", ", sortArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
               countCompare, countChange);

            // сортировка упорядоченного по возрастанию массива
            countChange = 0;
            countCompare = 0;
            double[] sortSortedUpArr = PiromidSort(sortArr, arr.Length);
            Console.WriteLine("\nОтсортированный по возрастанию: \n" + String.Join(", ", sortSortedUpArr));
            Console.WriteLine("{0} сравнений, {1} перессылок", countCompare, countChange);

            Array.Reverse(sortArr);
            countChange = 0;
            countCompare = 0;
            double[] sortSortedDownArr = PiromidSort2(sortArr, arr.Length);
            Console.WriteLine("\nОтсортированный по убыванию массив: \n" + String.Join(", ", sortSortedDownArr));
            Console.WriteLine("{0} сравнений, {1} перессылок", countCompare, countChange);
        }

        static int add2pyramid(double[] arr, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
                //countCompare += 2;
                countCompare++;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                countChange++;
                if (imax < N / 2) i = imax;
                //countCompare += 2;
            }
            countCompare++;
            return i;
        }

        public static double[] PiromidSort(double[] arr, int len)
        {
            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
                //countCompare++;
            }

            //шаг 2: сортировка
            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
            return arr;
        }

        static int add2pyramid2(double[] arr, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] > arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
                countCompare++;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] > arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
                //countCompare += 2;
                countChange++;
            }
            countCompare++;
            return i;
        }

        public static double[] PiromidSort2(double[] arr, int len)
        {
            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid2(arr, i, len);
                if (prev_i != i) ++i;
                //countCompare++;
            }

            //шаг 2: сортировка
            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid2(arr, i, k);
                }
            }
            return arr;
        }
    }
}
