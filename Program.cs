using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
            double[] usnum = new double[3];
            Console.WriteLine("ЗАПОЛНЕНИЕ МАССИВА");

                for (int i = 0; i < usnum.Length; i++)
            {
                Console.WriteLine("ВВЕДИТЕ ЧИСЛО ДЛЯ ЗАПОЛНЕНИЯ");
                string? inp1 = Console.ReadLine() ?? "";

                if (double.TryParse(inp1, CultureInfo.InvariantCulture, out usnum[i]) == false)
                {
                    Console.WriteLine("Ошбика - Текст не является числом");
                    Console.ReadKey();
                    continue;
                }
            }    
            Console.WriteLine("Вывод результата");
                for (int i = 0; i < usnum.Length; i++)
                {
                    Console.WriteLine($"под индексом {i} лежит {usnum[i]}");
                }
        }
   }

             
