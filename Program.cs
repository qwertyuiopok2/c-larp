using System.Buffers;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
namespace c_larp;
public class Bee
{
    public string? Name {get;  set;}
    public string? Role {get;  set;}
    public int Energy {get;  set;}
    public int CollectHoneyPerOneDay {get;  set;}

    public Bee(string? name, string? role, int energy, int collecthoneyperoneday)
    {
        Name = name;
        Role = role;
        Energy = energy;
        CollectHoneyPerOneDay = collecthoneyperoneday;
    }
}
public class BeeHive
{
    public int Id {get; set;}
    public string? Material {get; set;}
    public List<Bee> Bees {get; set;} //Матрешка!, список пчел внутри улья

    public BeeHive(int id, string? material, List<Bee> bees)
    {
        Id = id;
        Material = material;
        Bees = bees;
    }
}
public class ApiaryManager
{
    public List<BeeHive> Hivelist = new List<BeeHive>()
    {
        new BeeHive (1, "Дерево", new List<Bee>
        {
            new Bee ("Rage Bee", "Guard", 75, 25),
            new Bee ("Cool Bee", "Worker", 15, 75),
            new Bee ("Wasp Killer", "Attacker-Guard", 10, 0),
            new Bee ("Clown Bee", "Worker", 75, 25),
            new Bee ("Queen Bee", "Queen", 75, 0),
        }),
        new BeeHive(2, "Пластик", new List<Bee>
        {
            new Bee ("Smart Bee", "Worker", 80, 45),
            new Bee ("Big Bee", "Queen", 75, 0),
            new Bee ("Miner Bee", "Worker", 15, 75),
            new Bee ("Agressiv Bee", "Attacker-Guard", 100, 0),
            new Bee ("Danger Bee", "Guard", 18, 55),
        }),
        new BeeHive (3, "Дерево", new List<Bee>
        {
            new Bee ("Worker Bee", "Worker", 45, 65),
            new Bee ("Money Bee", "Guard", 95, 75),
            new Bee ("Stari Bog", "Queen", 75, 0),
            new Bee ("Fat Bee", "Worker", 10, 95),
            new Bee ("Strong Bee", "Attacker-Guard", 14, 0),
        })
    } ;

    public void Champion()
    {
        Console.WriteLine("Поиск самого продуктивного улья");
        BeeHive? champion = Hivelist.OrderByDescending(Bees => Bees.Bees.Sum(bee => bee.CollectHoneyPerOneDay)).FirstOrDefault();

        if (champion == null)
        {
            Console.WriteLine("На пасике нет ульев");
            return;
        }
        int totalHoney = champion.Bees.Sum(b => b.CollectHoneyPerOneDay);

        Console.WriteLine($"Champion Gladiator: {champion.Id} || {champion.Material}");
        Console.WriteLine($"Они всего собрали {totalHoney}");
    } 
}
public class Program
{
    static void Main(string[] args)
    {
        ApiaryManager hive = new ApiaryManager();
        List <Bee> TiredBee = hive.Hivelist.SelectMany(h => h.Bees).Where(bee => bee.Energy <= 20).ToList();
        var AllHoney = hive.Hivelist.SelectMany(h => h.Bees).Where(bee => bee.Role == "Worker").Sum(honey => honey.CollectHoneyPerOneDay);
        
        while(true)
        {
        Console.WriteLine("Добро пожаловать в Пасику");
        Console.WriteLine("- 1 Найти и покормить уставших пчел - ");
        Console.WriteLine("- 2 Сколько всего приносит улей в день - ");
        Console.WriteLine("- 3 Самый продуктивный улей - ");
        Console.WriteLine("- 4 Выйти с Пасики -");
        Console.WriteLine("- Выберите действие - ");
        string? command = Console.ReadLine();

        switch(command)
        {
        case "1":
            foreach (Bee tired in TiredBee)
            {
                Console.WriteLine($"{tired.Name} с ролью {tired.Role} требует подпитки у неё {tired.Energy} энергии");
                Console.WriteLine("Для подпитка бжел нажмите Enter");
                Console.ReadKey();
                Console.WriteLine($"Вы покормили пчелку {tired.Name} у нее прибавилось 25 энергии");
                tired.Energy += 25;
            }
            Console.ReadKey();
            break;

        case "2":
            Console.WriteLine($"За день ваши пчелы собирают {AllHoney} грамм");
            Console.ReadKey();
            break;
        case "3":
            hive.Champion();
            Console.ReadKey();
            break;
        case "4":
            Console.ReadKey();
            return;
        }
        }
        }
}

