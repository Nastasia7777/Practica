using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static int[] DaysInMonths = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        static bool IsLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            return false;
        }

        static int FindNumberOfLeapDays(int years)
        {
            int numberOfLeapDays = 0;
            for (int year = 0; year < years; year++)
            {
                if (IsLeapYear(year))
                {
                    numberOfLeapDays++;
                }
            }
            return numberOfLeapDays;
        }

        static int FindTotalNumberOfDays(int days, int months, int years)
        {
            int numberOfDays = 0;
            numberOfDays += 365 * years;
            for (int i = 0; i < months - 1; i++)
            {
                numberOfDays += DaysInMonths[i];
            }
            numberOfDays += days;
            numberOfDays += FindNumberOfLeapDays(years);
            if (IsLeapYear(years) && months >= 3)
            {
                numberOfDays++;
            }
            return numberOfDays;
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            string firstDate = sr.ReadLine();
            string[] partsOfFirstDate = firstDate.Split('.');
            int days1 = Convert.ToInt32(partsOfFirstDate[0]);
            int months1 = Convert.ToInt32(partsOfFirstDate[1]);
            int years1 = Convert.ToInt32(partsOfFirstDate[2]);
            string secondDate = sr.ReadLine();
            sr.Close();
            string[] partsOfSecondDate = secondDate.Split('.');
            int days2 = Convert.ToInt32(partsOfSecondDate[0]);
            int months2 = Convert.ToInt32(partsOfSecondDate[1]);
            int years2 = Convert.ToInt32(partsOfSecondDate[2]);
            int totalDays1 = FindTotalNumberOfDays(days1, months1, years1);
            int totalDays2 = FindTotalNumberOfDays(days2, months2, years2);
            int result = totalDays2 - totalDays1 + 1;
            sw.Write(result);
            sw.Close();
        }
    }
}
