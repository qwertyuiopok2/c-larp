using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
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
          List<Biboba> Zov = new List<Biboba>();
          Zov.Add(new Biboba {Name = "Artem", Status = "Admin", Time = 10, City = "Москва" });
          Zov.Add(new Biboba {Name = "Max", Status = "Guest", Time = 11, City = "Екатеринбург" });
          Zov.Add(new Biboba {Name = "Micha", Status = "Admin", Time = 5, City = "Орехово-Зуево" });
          Zov.Add(new Biboba {Name = "Liza", Status = "Admin", Time = 6, City = "Москва" });
          Zov.Add(new Biboba {Name = "Lesha", Status = "Guest", Time = 15, City = "Москва" });


            

          while(true)
          {
            Console.WriteLine("Система контроля доступа");
            Console.WriteLine("1 - Показать все логи");
            Console.WriteLine("2 - Показать всех админов из Москвы");
            Console.WriteLine("3 - Удалить всех гостей пришедших после 10");
            Console.WriteLine("4 - Выход из программы ");
            Console.WriteLine("\n Выберите опцию");
            Processmenu(Zov);
          }
            
        static  void Processmenu (List<Biboba> lox)
        {
            string? comand = Console.ReadLine();
            switch (comand)
            {
                case "1":
                    for (int i = 0; i < lox.Count ; i++)
                    {
                        Console.WriteLine($"Сотрудник -{lox[i].Name} , Статус -{lox[i].Status}, Время -{lox[i].Time} , Город -{lox[i].City} ");
                    }
                    Console.WriteLine("нажмите кнопку для завершения программы");
                    Console.ReadKey();
                    break;
                case "2":
                    for (int i = 0; i < lox.Count; i++)
                    {
                        if (lox[i].Status == "Admin" && lox[i].City =="Москва")
                            Console.WriteLine($"Сотрудник {lox[i].Name} из города {lox[i].City}");
                        }           
                    Console.WriteLine("Для выхода из программы нажмите любую кнопку");
                    Console.ReadKey();            
                    break;
                case "3":
                    for (int i = lox.Count - 1; i>= 0 ;  i--) // от конца к началу нужно для удаления элементов и проверка начинается с конца в начало чтобы после удаления
                    // элементов те которые сдвинутся влево не заставили цикл пропустить шаги
                    {
                        if (lox[i].Status == "Guest" && lox[i].Time > 10)
                        {
                            Console.WriteLine($"Удален гость: {lox[i].Name}");
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

public class Biboba
{
    public string? Name { get; set; } = string.Empty;
    public string? Status { get; set; } = string.Empty;
    public int Time { get; set; }
    public string? City { get; set; } = string.Empty;
}






   
             
