using System.Buffers;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        }
        else
        {
            Console.WriteLine($"Вы заправили {litrs}");
        }
        Console.WriteLine($"Вы заправили свою машину на {litrs} лит. теперь у вас {Fuel}");
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
    public void ReadyCars()
    {
        Console.WriteLine("Машины готовые к дальнему рейсу:");

        List<Car> Readycar = _cars.Where(Car => Car.Fuel > (Car.MaxFuel / 2)).ToList();

        if (Readycar.Count == 0)
        {
            Console.WriteLine("Ни одна машина ни готова к рейсу");
            return;
        }

        foreach(Car car in Readycar)
        {
            Console.WriteLine($"{car.Model} {car.Color} - готово, состояние его бака {car.Fuel}/{car.MaxFuel} litrs");
        }
        // ToList - создает отдельный новый список  не меняя старый для удобства который может быть изменен (только с нашими свойствами)
    }
    public void FoundCarModel(string carfound)
    {
        Console.WriteLine("Поиск машины...");
        
        // FirstOrDefault - поиск первой машины совпадающую с запросом
        // ToLower - упрощение можно писать не обращая внимание на заглавные буквы он их пропустит
        Car? carfund = _cars.FirstOrDefault(c => c.Model.ToLower() == carfound.ToLower());

        if (carfund == null)
        {
            Console.WriteLine($"Машина модели {carfound} была не найдена");
        }
        else
        {
            Console.WriteLine($"{carfund.Model} с цветом {carfund.Color} была найдена");
        }
    }
    public void fuelsortir()
    {

        Console.WriteLine("Сортировка автопарка по уровню топлива");

        if (_cars.Count == 0)
        {
            Console.WriteLine("Ошибка ваш автопарк пуст");
            return;
        }
        // OrderByDescending - сортировка по убыванию, а OrderBy - сортировка по возрастанию
        List<Car> carsort = _cars.OrderByDescending(c => c.Fuel).ToList();

        foreach(Car car in carsort)
        {
            Console.WriteLine($"{car.Model} с топливом {car.Fuel}");
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