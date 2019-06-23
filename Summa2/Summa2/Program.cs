using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summa2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            string number = sr.ReadToEnd();
            sr.Close();
            int x = Convert.ToInt32(number);
            int result = 0;
            for (int a = 1; a <= x - 3; a++)
            {
                for (int b = a; b <= x - a - 2; b++)
                {
                    for (int c = b; c <= x - a - b - 1; c++)
                    {
                        int d = x - a - b - c;
                        if (c <= d)
                        {
                            result++;
                        }
                    }
                }
            }
            sw.Write(result);
            sw.Close();
        }
    }
}
