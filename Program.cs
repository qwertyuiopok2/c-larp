using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace c_larp;

public class Car
{
    public string? Model {get; private set;}
    public string? Color {get; private set;}
    public double Fuel {get ; private set;}
    public double MaxFuel {get; private set;}


    public Car(string? model, string? color, double maxfuel)
    {
        Model = model;
        Color = color;
        if (maxfuel <= 0)
        {
            maxfuel = 50;   
        }
        MaxFuel = maxfuel;

        Fuel = maxfuel;
    }

    public bool Drive(int distantce)
    {
        double FuelNeeded = distantce * 0.1;

        if (FuelNeeded > Fuel)
        {

            Console.WriteLine("Нехватает топлива заправтесь");
            return false;

        }
        Fuel -= FuelNeeded;
        Console.WriteLine($"Вы успешно проехали {distantce}");
        return true;
    }

    public void ReFuel (double litrs)
    {
        if (litrs <= 0)
        {
            Console.WriteLine("Вы не можете заправить нуля литрами");
            return;
        }
        Fuel += litrs;
        if (Fuel >= MaxFuel)
        {
            Fuel = MaxFuel;
            Console.WriteLine($"Вы заправили полный бак в свою малыху а именно {MaxFuel} (удивительно)");
            return;
        }
        Console.WriteLine($"Вы заправили свою машину на {litrs} лит. теперь у вас {Fuel}");
        return;
    }   
}

public class GarageManager
{
    private List<Car> _cars = new List<Car>();
    private int _maxmestingarage;


    public GarageManager (int maxMestingarage)
    {
        _maxmestingarage = maxMestingarage;
    }

    public bool addcar (Car car)
    {
        if (_cars.Count > _maxmestingarage)
        {
            Console.WriteLine("Ошибка кол-во машин в гараже максимально");
            return false;
        }
        _cars.Add(car);
        Console.WriteLine("Ваша машина успешно добавлена в гараж");
        Console.WriteLine($"{_cars.Count} авто в вашем гаража");
        return true;
    }
    public void ShowAllCars()
    {
        Console.WriteLine("Список гаража");
        if (_cars.Count == 0)
        {
            Console.WriteLine("Ваш гараж пуст");
            return;
        }
        else if (_cars.Count != 0)
        {
            foreach (Car car in _cars)
            {
                Console.WriteLine($"{car.Model} с {car.Color} цветом и {car.Fuel} литрами топлива из максимальных {car.MaxFuel}");
            }
        }
    }
    public void DriveAllCars(int distance)
    {
        Console.WriteLine($"Отправка автопарка в рейс на {distance}");

        foreach (Car car in _cars)
        {
            car.Drive(distance);

        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        GarageManager manager = new GarageManager(3);

        while (true)
        {
            Console.WriteLine("\n Меню автопарка");
            Console.WriteLine("1 - Показать машины в гараже ");
            Console.WriteLine("2 - Добавить новую машину");
            Console.WriteLine("3 - Отправить весь автопарк в рейс");
            Console.WriteLine("4 - выйти ");
            Console.WriteLine("Выберите действие");

            string? op =  Console.ReadLine();

            switch (op)
            {
                case "1":
                manager.ShowAllCars();
                continue;

                case "2":

                Console.Write("Введите модель машины ");
                string? model = Console.ReadLine();

                Console.Write("Введите цвет машины ");
                string? color = Console.ReadLine();

                Console.Write("Введите объем бака машины в литрак ");

                if (double.TryParse(Console.ReadLine(), out double maxfuel))
                {
                    Car newCar = new Car (model, color, maxfuel);
                    if (manager.addcar(newCar))
                    {
                        Console.WriteLine("Машина успешно добавлена в гараж");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка неверый формат объема бака");
                }
                break;

                case "3":
                {
                    Console.WriteLine("Введите дистанцию для рейса в метрах");
                    
                    if(int.TryParse(Console.ReadLine(), out int dist))
                    {
                        manager.DriveAllCars(dist);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка неверный формат дистанции");
                    }
                    break;
                }
                
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