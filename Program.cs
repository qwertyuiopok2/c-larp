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
using System.Xml;
using Microsoft.VisualBasic;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
          List<string> Zov = new List<string>();
          Zov.Add("Eugene | Admin | 10  | Екатеринбург");
          Zov.Add("Masha | Guest | 11  |  Москва");
          Zov.Add("Eben | Admin | 6  | Екатеринбург");
          Zov.Add("Petyx | Guest | 9  | Стокгольм");
          Zov.Add("Pedix | Admin | 15  | Москва");


            

          while(true)
          {
            Console.WriteLine("Система контроля доступа");
            Console.WriteLine("1 - Показать все логи");
            Console.WriteLine("2 - Показать всех админов");
            Console.WriteLine("3 - Удалить всех гостей пришедших после 10");
            Console.WriteLine("4 - Выход из программы ");
            Console.WriteLine("\n Выберите опцию");
            Processmenu(Zov);
          }
            
        static  void Processmenu (List<string> lox)
        {
            string? comand = Console.ReadLine();
            switch (comand)
            {
                case "1":
                    for (int i = 0; i < lox.Count ; i++)
                    {
                        Console.WriteLine($"{lox[i]}");
                    }
                    Console.WriteLine("нажмите кнопку для завершения программы");
                    Console.ReadKey();
                    break;
                case "2":
                    for (int i = 0; i < lox.Count; i++)
                    {
                        if (lox[i].Contains("Admin")) //Contains обработчик данных внутри листа при строгом соблюдении того что мы укажем в листе и скобках. Удобен для условий
                        {  
                            Console.WriteLine($"{lox[i]}");
                        }                        
                    }
                    Console.WriteLine("Для выхода из программы нажмите любую кнопку");
                    Console.ReadKey();
                    break;
                case "3":
                    for (int i = lox.Count - 1; i>= 0 ;  i--) // от конца к началу нужно для удаления элементов и проверка начинается с конца в начало чтобы после удаления
                    // элементов те которые сдвинутся влево не заставили цикл пропустить шаги
                    {
                        string[] names = lox[i].Split("|");

                        int time = int.Parse(names[2].Trim()); // Trim() - убирает лишние пробелы в начале/конце строки внутри разрезанного массива.
                        // Это нужно для валидации текста (чтобы "Guest " совпало с "Guest")
                        // и для правильной типизации (чтобы сконвертировать " 11 " в число int без ошибок)
                        if (names[1].Contains("Guest") && time > 10 )
                        {
                            lox.RemoveAt(i);
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("Введите команду - stop - для выхода из программы");
                    string? leave = Console.ReadLine();
                    if (leave == "stop")
                    {
                       Environment.Exit(0); //выйти из среды
                    }
                    break;

            }
        }
        }    
     }






   
             
