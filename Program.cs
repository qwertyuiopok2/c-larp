using System.Buffers;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace c_larp;

public class FuelType
{
    public int Number {get; private set;}
    public string? Fueltype {get; private set;}
    public double PricePerLitr {get; private set;}
    public double _fuelAvailable;

    public FuelType (int number, string? fueltype, double priceperlitr, double fuelavailable)
    {
        Number = number;
        Fueltype = fueltype;
        PricePerLitr = priceperlitr;
        _fuelAvailable = fuelavailable;
    }
}
public class GasStationManager
{
    List<FuelType> GasStation = new List<FuelType>()
    {
        new FuelType(1, "95", 70.5 , 400),
        new FuelType(2, "100", 120.4 , 200),
        new FuelType(3, "ДТ", 50.1 , 500),
        new FuelType(4, "92", 60.2 , 300),
        new FuelType(5, "Электро", 70.5 , 100)
    };
    public bool DispanceFuel(string? litrs, string? type)
    {
        if (double.TryParse(litrs, out double result) == false)
        {
            return false;
        }
        if (result < 0)
        {
            return false;
        }
        if (type == null)
        {
            return false;
        }
        List<FuelType> needcolonka = GasStation.Where(c => type == c.Fueltype).ToList();
        foreach(FuelType lox in needcolonka)
        {
            if(lox._fuelAvailable < result)
            {
                return false;
            }
            else
            {
                lox._fuelAvailable = lox._fuelAvailable - result;
            }
        }
        Console.ReadKey();
        return true;
    }
    public void ShowType()
    {
        List<string?> typelist = GasStation.Select(c => c.Fueltype).ToList();
        int num = 1;
        foreach(string? type in typelist)
        {
            Console.WriteLine($"{num} - {type}");
            num ++;
        }
        Console.ReadKey();
    }

    public void ConditionLox()
    {
        List<FuelType> Condition = GasStation.Where(c => c._fuelAvailable > 0).ToList();

        foreach(FuelType state in Condition)
        {
            Console.WriteLine($"В {state.Number} колонке {state._fuelAvailable} литров");
        }
        Console.ReadKey();
    }
}
class Programm 
{
    static void Main (string[] args)
    {
        GasStationManager manager = new GasStationManager();

        while(true)
        {
            Console.WriteLine(" - Бензоколонки - ");
            Console.WriteLine(" 1 - Заправка машины - ");
            Console.WriteLine(" 2 - Показать все виды топлива - ");
            Console.WriteLine(" 3 - Увидеть количество топлива в колонке - ");
            Console.WriteLine(" 4 - Выход с программы - ");
            Console.WriteLine(" - Выберите действие - ");

            string? op = Console.ReadLine();

            switch (op)
            {
                case "1":
                Console.WriteLine("Заправка");
                Console.WriteLine("Введите вид топлива который хотите заправить : 92, 95, 100, ДТ, Электро");
                string? typ = Console.ReadLine();
                Console.WriteLine("Введите сколько нужно заправить");
                string? litrs = Console.ReadLine();
                if (!manager.DispanceFuel(litrs, typ))
                {
                    Console.WriteLine("Ошибка");
                }
                else
                {
                    Console.WriteLine("Заправка окончена");
                }
                continue;

                case "2":
                Console.WriteLine("Все ввиды топлива:");
                manager.ShowType();
                continue;

                case "3":
                Console.WriteLine("Состояние колонок");
                manager.ConditionLox();
                continue;

                case "4":
                Console.WriteLine("Выход с программы");
                return;

                default:
                Console.WriteLine("Ошибка действие некорректно");
                continue;
            }

        }
    }
}