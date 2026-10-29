using System.Buffers;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
namespace c_larp;

public class Hero
{
    public string? Name { get; private set; } 
    public int Health { get ; private set; }
    public int Damage { get; private set; }

    public Hero (string? name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }

        Console.WriteLine($"{Name} получил {damage} едениц урона текущие хп {Health}");
    }
    public void Attack(Hero target)
    {
        Console.WriteLine($"{Name} замахивается мечом на {target.Name}");

        target.TakeDamage(Damage);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать на кровавую арену смерти");

        Hero warrior = new Hero("Джентельмен", 500, 70);
        Hero monster = new Hero("Пекка", 250, 50);

        Console.WriteLine($"На арену выходят {warrior.Name} с дамагом {warrior.Damage} и HP {warrior.Health}");
        Console.WriteLine("Нажмите enter чтобы продолжить...");
        Console.ReadLine();

        int round = 1;

        while(warrior.Health > 0 && monster.Health > 0)
        {
            Console.Clear();
            Console.WriteLine($"Раунд номер {round} начинается");
            Console.WriteLine($"{warrior.Name}: {warrior.Health} HP | {monster.Name}: {monster.Health} HP");


            warrior.Attack(monster);

            if (monster.Health <= 0)
            {
                Console.WriteLine($"монстер {monster.Name} пал");
                Console.WriteLine($"Победил {warrior.Name}");
                break;
            }
            Console.WriteLine();

            if (warrior.Health <= 0)
            {
                Console.WriteLine($"воин {warrior.Name} пал");
                Console.WriteLine($"победил {monster.Name}");
                break;
            }

            round++;

            Console.WriteLine("\n Нажмите Enter чтобы продолжить . . .");
            Console.ReadKey();
        }
    }
}