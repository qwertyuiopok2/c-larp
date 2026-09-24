using System.Reflection.Metadata;

namespace c_larp;

public class OchkoPredmet
{
    public string? Name { get; set; } = string.Empty;
    public string? Redkost { get; set; } = string.Empty;
    public int Damage { get; set; }
    public bool Iseq {get; set;} = false; //true в руках false в рюкзаке
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
        Console.WriteLine("-- 4 - Взять предмет в руки --");
        Console.WriteLine("-- 5 - Выйти из инвентаря --");
        Console.WriteLine("-- Выберите действие --");

        string? op = Console.ReadLine();

        switch (op)
        {
            case "1":
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    string eq = inventory[i].Iseq ? "[В руках]" : ""; // ? заменяет  , а : заменяет elif

                    Console.WriteLine($"{inventory[i].Name} с редкостью {inventory[i].Redkost}, с дополнительным уроном {inventory[i].Damage} - {eq} ");
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
                if (inventory.Count >= 5)
                {
                    Console.WriteLine("Ошибка инвентарь заполнен");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Введите название предмета");
                string? newitem = Console.ReadLine();
                if (newitem == null)
                {
                    Console.WriteLine("Ошибка");
                    Console.ReadKey();
                    break;
                }
                bool duplicate = false; //флаг проверки
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].Name == newitem)
                    {
                        Console.WriteLine("Ошибка");
                        Console.ReadKey();
                        duplicate = true;
                        break; //выход из цикла фор ведь дубликат найден
                    }
                }
                if (duplicate)
                {
                    continue;
                }
                Console.WriteLine("Введите редкость предмета: Basic, Rare, Legendary");
                string? newredkost = Console.ReadLine();
                if (newredkost != "Basic" && newredkost != "Rare" && newredkost != "Legendary")
                {
                    Console.WriteLine("Ошибка");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Введите урон предмета");
                string? newnum = Console.ReadLine();
                if (int.TryParse(newnum, out int num1) == false || num1 < 0)
                {
                    Console.WriteLine("Ошибка");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Добавляем предмет...");
                inventory.Add(new OchkoPredmet{Name = newitem, Redkost = newredkost, Damage = num1});
                Console.WriteLine("\n Предмет успешно добавлен");
                Console.WriteLine("Нажмите любую кнопку для выхода");
                Console.ReadKey();
                break;
            }
            case "4":
            {
                Console.WriteLine("Экипировка оружия");
                Console.WriteLine("Введите точное название предмета, который хотите взять в руки");
                string? eqname = Console.ReadLine();
                bool itemfound = false;
                for (int i = 0; i < inventory.Count; i++) // Проверяем весь список чтобы была информация о всех предметах и соответственно если название предмета в массиве существует оно может быть экипировано то есть введено нами чтобы мы могли его экипировать
                {
                    if (inventory[i].Name == eqname)
                    {
                        for (int j = 0; j < inventory.Count; j++) // внутренний цикл обнуляющий весь инвентарь после ввода того предмета который мы хотим экипировать (поменять статус на true)
                        {
                            inventory[j].Iseq = false;
                        }
                        inventory[i].Iseq = true;
                        itemfound = true;
                        break;
                    }
                }
                
                if (itemfound != true)
                {
                    Console.WriteLine("Предмет не найден ошибка");
                }
                else
                {
                    Console.WriteLine("предмет добавлен");
                }
                    Console.ReadKey();
                    break;
            }

            case "5":
            {
                Console.WriteLine($"\n Для выхода из программы нажимет любую кнопку");
                Console.ReadKey();
                return;
            }
        }
        }
    }
}
