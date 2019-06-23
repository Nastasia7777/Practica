using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    public class Program
    {
        const int order = 10;
        public static bool okReading;
        public static int[][] matrix { get; set; }
        public static string symbols { get; set; }
        public static string cryptSymbols { get; set; }
        public static string decryptedSymbols { get; set; }

        private static int[] ReadValue(out bool ok, string data) //Чтение матрицы по строкам с проверкой
        {
            ok = true;
            int[] digits = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
                digits[i] = Convert.ToInt32(data[i]) - 48;
            for (int i = 0; i < digits.Length; i++)
                if ((digits[i] != 0) && (digits[i] != 1))
                    ok = false;
            return digits;
        }

        public static int[][] ReadMatrix(StreamReader inputMatrix, out bool okReading) //чтение матрицы из файла
        {
            int[][] matrix = new int[order][];
            okReading = true;
            try
            {
                for (int row = 0; row < order && okReading; row++)
                {
                    string data = inputMatrix.ReadLine();
                    matrix[row] = ReadValue(out okReading, data);
                    if (matrix[row].Length != order)
                        okReading = false;
                }
            }
            catch (Exception)
            {
                okReading = false;
            }

            if (okReading)
                okReading = CheckMatrix(matrix);

            inputMatrix.Close();
            return matrix;
        }

        static bool CheckMatrix(int[][] matrix) // проверка пригодности матрицы быть ключом
        {
            if (CheckMatrixValues(matrix))
            {

                for (int row = 0; row < order / 2; row++)
                    for (int column = 0; column < order / 2; column++)
                    {
                        if (matrix[row][column] + matrix[column][order - 1 - row] // поскольку среди этих только
                            + matrix[order - 1 - row][order - 1 - column]         // одно значение 0, а остальные 1, 
                            + matrix[order - 1 - column][row] != 3)               // то сумма только 3
                        {
                            return false;
                        }
                    }

            }
            else
                return false;

            return true;
        }

        static bool CheckMatrixValues(int[][] matrix) // проверка значений матрицы (0 или 1) 
        {
            bool okValues = true;

            for (int row = 0; row < order; row++)
            {
                for (int column = 0; column < order; column++)
                    if (matrix[row][column] != 0 && matrix[row][column] != 1)
                    {
                        okValues = false;
                        break;
                    }

                if (!okValues)
                    break;
            }

            return okValues;
        }

        public static string ReadString(StreamReader inputString, out bool okReading) // чтение строки для шифрования и дешифрования
        {
            string symbols = string.Empty;
            okReading = true;

            try
            {
                symbols = inputString.ReadLine();
                inputString.Close();
            }
            catch (Exception)
            {
                okReading = false;
            }

            if (symbols == null || okReading && symbols.Length != 100)
            {
                okReading = false;
            }

            return symbols;
        }

        public static string Encrypt(int[][] matrix, string symbols) //шифрование последовательности symbols решеткой matrix
        {
            int currentSymbol = 0;
            string result = string.Empty;

            char[][] cryptMatrix = new char[order][];

            for (int row = 0; row < order; row++)
                cryptMatrix[row] = new char[order];

            for (int turn = 1; turn <= 4; turn++)
            {
                // запись символов в свободные клетки
                for (int row = 0; row < order; row++)
                    for (int column = 0; column < order; column++)
                        if (matrix[row][column] == 0)
                        {
                            cryptMatrix[row][column] = symbols[currentSymbol];
                            currentSymbol++;
                        }

                //поворот матрицы
                TurnMatrix(ref matrix);
            }

            result = ReadEncryptResult(cryptMatrix);

            return result;
        }

        static void TurnMatrix(ref int[][] matrix) //поворот матрицы на 90 градусов по часовой стрелке 
        {
            for (int row = 0; row < order / 2; row++)
                for (int column = 0; column < order / 2; column++)
                {
                    int temp = matrix[row][column];
                    matrix[row][column] = matrix[column][order - 1 - row];
                    matrix[column][order - 1 - row] = matrix[order - 1 - row][order - 1 - column];
                    matrix[order - 1 - row][order - 1 - column] = matrix[order - 1 - column][row];
                    matrix[order - 1 - column][row] = temp;
                }
        }

        static string ReadEncryptResult(char[][] matrix) // чтение зашифрованной последовательности 
        {
            string result = string.Empty;

            for (int row = 0; row < order; row++)
                for (int column = 0; column < order; column++)
                    result += matrix[row][column].ToString();

            return result;
        }

        public static string Decipher(int[][] matrix, string code) // дешифрование последовательности code матрицей matrix
        {
            char[][] codeMatrix = new char[order][];
            int currentSymbol = 0;

            // запись последовательности в матрицу
            for (int row = 0; row < order; row++)
            {
                codeMatrix[row] = new char[order];

                for (int column = 0; column < order; column++)
                {
                    codeMatrix[row][column] = code[currentSymbol];
                    currentSymbol++;
                }
            }

            string result = string.Empty;

            for (int turn = 1; turn <= 4; turn++)
            {
                for (int row = 0; row < order; row++)
                    for (int column = 0; column < order; column++)
                        if (matrix[row][column] == 0)
                            result += codeMatrix[row][column].ToString();

                //поворот матрицы
                TurnMatrix(ref matrix);
            }

            return result;
        }

        static void Main()
        {
            bool okReading = true;
            matrix = ReadMatrix(new StreamReader(@"C: \Users\nasta\source\repos\Task_11\Task_11\bin\Debug\Матрица.txt", Encoding.Default), out okReading);
            symbols = ReadString(new StreamReader(@"C:\Users\nasta\source\repos\Task_11\Task_11\bin\Debug\Текст.txt", Encoding.Default), out okReading);
            cryptSymbols = Encrypt(matrix, symbols);
            decryptedSymbols = Decipher(matrix, cryptSymbols);
            Console.WriteLine("Задание № 11 \n Зашифровать и расшифровать данную последовательность с помощью матрицы-ключа");
            Console.WriteLine($"\n Исходный текст: {symbols}");
            Console.WriteLine($"\n Текст после шифрования: {cryptSymbols}");
            Console.WriteLine($"\n Текст после дешифрования: {decryptedSymbols}");
            Console.WriteLine("\nДля выхода нажмите клавишу Enter...");
            Console.ReadKey();

        }
    }
}