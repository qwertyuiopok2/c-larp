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

public class OchkoPredmet
{
    public string? Name { get; set; } = string.Empty;
    public string? Redkost { get; set; } = string.Empty;
    public int Damage { get; set; }
}

class Inventory
{
    static void Main(string[] lox)
    {
        List<OchkoPredmet> inventory = new List<OchkoPredmet>();

        inventory.Add(new OchkoPredmet{Name = "ржавый меч", Redkost = "Basic", Damage = 2});
        inventory.Add(new OchkoPredmet{Name = "Палочка", Redkost = "Rare", Damage = 10});
        inventory.Add(new OchkoPredmet{Name = "Рапира", Redkost = "Legendary", Damage = 50});
        while (true)
        {
        Console.WriteLine("-- Ваш инвентарь --");
        Console.WriteLine("-- 1 - Показать инвентарь --");
        Console.WriteLine("-- 2 - Показать только легендарные предметы --");
        Console.WriteLine("-- 3 - Добавить предмет в инвентарь --");
        Console.WriteLine("-- 4 - Выйти из инвентаря --");
        Console.WriteLine("-- Выберите действие --");

        string? op = Console.ReadLine();

        switch (op)
        {
            case "1":
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"{inventory[i].Name} с редкостью {inventory[i].Redkost}, с дополнительным уроном {inventory[i].Damage} ");
                }
                Console.WriteLine("ВАШ ИНВЕНТАРЬ");
                break;
            }

            case "2":
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].Redkost == "Legendary")
                    {
                        Console.WriteLine($"\n С легендарной редкостью предмет {inventory[i].Name}  с доп уроном {inventory[i].Damage}");
                    }
                }
                break;
            }

            case "3":
            {
                Console.WriteLine("Введите название предмета, которого хотим добавить");
                string? newitem = Console.ReadLine();
                if (newitem != null)
                {
                    Console.WriteLine("Введите редкость предмета, которого хотим добавить: Basic, Rare, Legendary");
                    string? newredkost = Console.ReadLine();
                    if (newredkost == "Basic" || newredkost == "Rare" || newredkost == "Legendary")
                    {
                        Console.WriteLine("Введите сколько дополнительного урона вносит данное оружие");
                        string? num = Console.ReadLine();
                        if(num != null)
                        {
                            if (int.TryParse(num, out int num1) == true)
                            {
                                inventory.Add(new OchkoPredmet{Name = newitem, Redkost = newredkost, Damage = num1});
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ОШИБКА");
                                Console.ReadKey();
                                return;
                            }

                        }
                        else 
                        {
                            Console.WriteLine("ОШИБКА");
                            Console.ReadKey();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ОШИБКА");
                        Console.ReadKey();
                        return;
                    }
                } 
                else 
                {
                    return;
                }               

            }

            case "4":
            {
                Console.WriteLine($"\n Для выхода из программы нажимет любую кнопку");
                Console.ReadKey();
                return;
            }
        }
        }
    }
}
