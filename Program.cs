using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
            
            Console.WriteLine("\n Бэкенд серверной логики");
            int[] serv = [12, 45, 5, 90, 23, 150, 4];
            int sum = 0;

            Console.WriteLine($"\n ошибки дневного массива по часам");
            PrintArray(serv);

            foreach (int num in serv)
            {
               sum += num;
            }
            Console.WriteLine($"Колчество ошибок в этом дне {sum}");

            BackEndSort(serv);
            Console.WriteLine();
            

            Sortirovka(serv);
            Sortirovmassiv(serv);
            
        }    

        static void PrintArray (int[] lox)
        {
            for (int i = 0; i < lox.Length; i++ )
            {
                Console.WriteLine($"в {i} часу {lox[i]} ошибок");
            }
            Console.WriteLine("");
        }

        static void BackEndSort (int[] lox)
        {
            Console.WriteLine("\n вывод часа в котором больше 50 ошибок");
            for (int i = 0; i < lox.Length; i++)
            {
                if (lox[i] > 50)
                {
                    Console.WriteLine($"В часу {i} выявленно {lox[i]} ошибок и оно больше 50");
                }
            }
        }
        static void Sortirovka (int [] lox)
        {
            for (int i = 0; i < lox.Length; i++)
            {
                for (int p = 0; p < lox.Length - 1;  p++)
                {
                    if (lox[p] > lox[p + 1])
                    {
                        int temp = lox[p];
                        lox[p] = lox[p + 1];
                        lox[p + 1] = temp;
                    }
                }
            }
        }
        static void Sortirovmassiv (int[] lox)
        {
            Console.WriteLine("Отсортированный вариант дневного массива ошибок");
            foreach (int errors in lox) //фор ич оператор позволяющий работать сразу всеми данными массива
            {
                Console.WriteLine($"{errors}");
            }
        }
    }

   
             
