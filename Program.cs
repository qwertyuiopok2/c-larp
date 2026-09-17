using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
            string?[] Invent = new string[3];
            Invent[1] = "меч новичка";

            while (true)
            {
                Console.Clear();
                Console.WriteLine ("ваш инвентарь");

                for (int i = 0 ; i < Invent.Length; i++)
                {
                    if (Invent == null)
                    {
                        Console.WriteLine("В ячейке пусто");
                    }
                    else 
                    {
                        Console.WriteLine($"В слоте {i}, {Invent[i]} ");
                    }

                }
            bool isFull = true;
            Console.WriteLine("Введите название нового предмета для добавления в инвентарь");
            string? newitem = Console.ReadLine();
            if (newitem == "")
            {
                Console.WriteLine("ошибка");
                Console.ReadKey();
                continue;
            }
            for (int i = 0 ; i < Invent.Length; i++)
              {
                if (Invent[i] == null ) 
                {
                    Invent[i] = newitem;
                    Console.WriteLine($"предмет {Invent[i]} добавлен");
                    isFull = false;
                    break;
                }
              }
                if (isFull == false)
                {
                    Console.WriteLine("введите y для очистки инвенторя или n для отмены");
                    string? lox = Console.ReadLine();
                    if (lox == "y")
                    {
                        Invent[0] = null;
                        Invent[2] = null;
                        
                    }
                 
                    else if (lox == "n")
                    {
                        Console.WriteLine("отмена очистки инвенторя");
                        
                    }
                    else
                    {
                        Console.WriteLine("ошибка нажмите кнопку чтобы остановить программу");
                        Console.ReadKey();
                        break;
                    }
            
                    

                }

            if (Invent[0] != null && Invent[2] != null)
            {
                break;
            }
              }

            }

        
      
        }
   

             
