using System.Buffers;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
namespace c_larp;

public class Car
{
    public string? Model {get; private set;} 
    public int Fuel {get ; private set;}
    public int MaxFuel {get; private set;}
    public bool Fix {get; private set;} = false;
    public string? CarDriver {get; private set;}



    public Car(string? model, int fuel, int maxfuel, bool fix, string? cardriver)
    {
        Model = model;
        Fuel = fuel;
        MaxFuel = maxfuel;
        Fix = fix;
        CarDriver = cardriver;
    }
}

public class FleetManager
{
    private List<Car> _cars = new List<Car>()
    {
        new Car("VOLVO", 200, 400, false, "Steve"),
        new Car("PedroMobil", 500, 700, false, "SteveJobs"),
        new Car("Uber", 50, 200, true, "Pedro")
    };
    public void ShowAllDrivers()
    {
        Console.WriteLine("Вот все водители --");

        List<string?> drivers = _cars.Select(c => c.CarDriver).ToList();

        foreach (string? name in drivers)
        {
            Console.WriteLine($"Водитель {name}");
        }
    }
    public void CheckEmergency()
    {
        Console.WriteLine("Проверка автопарка на низкий уровень топлива");

        bool cars = _cars.Any(c => c.Fuel < 15 && !c.Fix);

        if (cars)
        {
            Console.WriteLine("Заправтесь");
        }
        else
        {
            Console.WriteLine("Все в порядке");
        }
    }
    public void Printfixcars()
    {
        Console.WriteLine("Идет подсчет машин");

        int fixcars = _cars.Count(c => c.Fix);

        int nfixcars = _cars.Count - fixcars;

        Console.WriteLine($"Всего машин {_cars.Count}");
        Console.WriteLine($"В ремонте из них {fixcars}");
        Console.WriteLine($"Остальные в количестве {nfixcars} работают исправно");
    }

    public void ShowTopThreeFuelCars()
    {
        Console.WriteLine("ТОП 3 МАШИНЫ ПО ЗАПРАВЛНОМУ ТОПЛИВУ");

        List<Car> top3 = _cars.OrderByDescending(c => c.Fuel).Take(3).ToList();

        int position = 1;
        foreach(Car car in top3)
        {
            Console.WriteLine($"{car.Fuel}/{car.MaxFuel} л в машине {car.Model} - {position} место");
            position++;
        }
    }

}

public class Program
{
  
    static void Main(string[] args)
    {

        FleetManager fleetconstrukt = new FleetManager();
        

        while (true)
        {
            Console.WriteLine("\n Меню автопарка");
            Console.WriteLine("1 - Показать всех водителей");
            Console.WriteLine("2 - Проверка уровня топлива машин");
            Console.WriteLine("3 - Топ 3 машины по уровню топлива");
            Console.WriteLine("4 - выйти ");
            Console.WriteLine("Выберите действие");

            string? op =  Console.ReadLine();

            switch (op)
            {
                case "1":
                fleetconstrukt.ShowAllDrivers();
                Console.ReadKey();
                continue;
                case "2":
                fleetconstrukt.CheckEmergency();
                Console.ReadKey();
                continue;
                case "3":
                fleetconstrukt.ShowTopThreeFuelCars();
                Console.ReadKey();
                continue;
                
                case "4":
                {
                    Console.WriteLine("Выход из программы");
                    return;
                }

                default:
                Console.WriteLine("Неверный пункт в меню");
                break;
            }
        }

    }
}