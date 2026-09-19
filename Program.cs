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
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
          
          List<string> names = new List<string>();
          names.Add("Admin_Alex");
          names.Add("Artem");
          names.Add("Admin_Misha");
          names.Add("Andrew");
          names.Add("Max");
         
            while(true)
            {
                Console.WriteLine("\n введите имя или выйдите из программы командой stop");
                string? am = Console.ReadLine() ??"" ;
                if (am == "stop")
                {
                    break;
                }
                


                if (int.TryParse(am, out int num1) == true)
                {
                    Console.WriteLine("error");
                    Console.ReadKey();
                    continue;
                }  
                if (am == "")
                {
                    Console.WriteLine("имя не может быть пустым");
                    Console.ReadKey();
                    continue;
                }
            
            bool useradmin = am.StartsWith("Admin_");

                if (useradmin)
                {
                    Console.WriteLine("Вы админ вот все известные вам админы");
                }
                else
                {
                    Console.WriteLine("Вы обычный пользователь");
                }
                
                foreach(string name in names)
                {
                    bool listadmins = name.StartsWith("Admin_");
                    if (useradmin && listadmins)
                    {
                        Console.WriteLine($"{name}");
                    }
                    else if (!useradmin && !listadmins)
                    {
                        Console.WriteLine($"{name}");
                    }

                }
                Console.WriteLine("Введите команду stop для остановки программы");
                string? command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                else if (command == "killadmins")
                {
                
                    for (int i = 0; i < names.Count; i++)
                    {
                    names.Remove("Admin_Alex");
                    names.Remove("Admin_Misha"); //удаление переменной из динамического массива
                    }
                Console.WriteLine();
                for (int i = 0; i < names.Count; i++)
                {    
                Console.WriteLine($"{names[i]}");
                }
                
                }
            }
        }
   }

   
             
