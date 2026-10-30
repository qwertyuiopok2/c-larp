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



        List<Hero> Heroes = new List<Hero>()
        {
            new Hero("ЭлектроГигант", 1000, 45),
            new Hero("Гигант", 750, 25 ),
            new Hero("Гоблин", 300, 80)
        };

        List<Hero> Villains = new List<Hero>()
        {
            new Hero("Зёлёнкий", 1000000, 125),
            new Hero("Золочевски", 100, 10),
            new Hero("Лох", 300, 25)
        };

        int round = 1;

        while(Heroes.Any(c => c.Health > 0) && Villains.Any(c => c.Health > 0))
        {
            Console.Clear();
            Console.WriteLine($"раунд - {round} начинается ");
            


            int totalHeroesHp = Heroes.Sum(c => c.Health);
            int totalVilianceHp = Villains.Sum(c => c.Health);

            Console.WriteLine($"Общее здоровье героев {totalHeroesHp} HP ");
            Console.WriteLine($" Общее здоровье злодеев {totalVilianceHp} HP");

            Console.WriteLine("Очередь героев");
            foreach (var HEROES in Heroes)
            {
                if (HEROES.Health <= 0)
                {
                    Console.WriteLine($"{HEROES.Name} мертв");
                    continue;
                }

                Hero weakestMonster = Villains.Where(c => c.Health > 0).OrderBy(c => c.Health).FirstOrDefault();

                if (weakestMonster != null)
                {
                    HEROES.Attack(weakestMonster);
                }

                if (!Villains.Any(Villains => Villains.Health > 0))
                {
                    break;
                }

                Console.WriteLine($"\nНажмите Enter чтобы монстры ответили своим ударом...");
                Console.ReadKey();
            }
            Console.WriteLine("Ход монстров");
            foreach(var VILLAINCE in Villains)
            {
                if (VILLAINCE.Health <= 0)
                {
                    Console.WriteLine($"{VILLAINCE.Name } мертв");
                    continue;
                }

                Hero weakestHero = Heroes.Where(c => c.Health > 0).OrderBy(c => c.Health).FirstOrDefault();

                if (weakestHero != null)
                {
                    VILLAINCE.Attack(weakestHero);
                }

                if (!Heroes.Any(c => c.Health > 0))
                {
                    break;
                }
                round ++;
                Console.WriteLine("Нажмите Enter чтобы продолжить бой");
                Console.ReadKey();
            }
            Console.WriteLine("БОЙ ОКОНЧЕН");

        }
            if (Heroes.Any(Hp => Hp.Health > 0))
            {
                Console.WriteLine("ГЕРОИ ПОБЕДИЛИ УРА УРА УВА");
            }
            else
            {
                Console.WriteLine("МОНСТРЫ ПОБЕДИЛИ НЕ УРА НЕ УРА НЕ УВА");
            }
            Console.ReadKey();
    }
}