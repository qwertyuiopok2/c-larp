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
        int[] num = {90, 185, 20, 40, 10};
        
        Console.WriteLine("оригинальный массив");
        Pudge(num);

        Console.WriteLine("отсортированный метод");
        Sortpudge(num);
        Pudge(num);
        }


        static void Pudge(int[] lox)
        {
            for (int i = 0; i < lox.Length; i++)
            {

                Console.WriteLine(lox[i] + "");

            }
            Console.WriteLine("");
        }
        

        static void Sortpudge(int[] lox)
        {
            for (int p = 0; p < lox.Length; p++)
            {
                for (int i = 0; i < lox.Length - 1; i++)
                {
                    if (lox[i]> lox[i + 1])
                    {
                        int temp = lox[i];
                        lox[i] = lox[i + 1];
                        lox[1 + i] = temp;
                    }
                }
            }
        }
   }

             
