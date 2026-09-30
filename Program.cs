using System.Buffers.Binary;
using System.Collections;
using System.Data;
using System.Dynamic;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks.Sources;

namespace c_larp;
public class Car
{
    public string? Model {get; set; }
    public string? Color {get; set; }
    public int Horespower {get; set; }


    public Car(string? model, string? color, int horespower)
    {
        Model = model;
        Color = color;
        Horespower = horespower;


        if (horespower <= 0)
        {
            Console.WriteLine("Мощность не может быть 0, установленна минимальная мощность 1");
            Horespower = 1;
        }

        Console.WriteLine($"Выпущена новая марка машины {Model}");
    }
    public Car(string? color) // Перегрузка конструкторами на примере (нужно вместить какие-то свойство, которые мы можем заранее заполнить в отдельном классе, а какие уже заполнены)
    {
        Model = "Питбуль";
        Color = color;
        Horespower = 400;
    }

    public void Printinfo()
    {
        Console.WriteLine($"[ГАРАЖ]: Автомобиль: {Model}, Цвет: {Color}, Мощность {Horespower}");
    }    



    public void RePaint(string NewColor)
    {
        Color = NewColor;

        Console.WriteLine($"Тюнниг: Машина: {Model}, успешно перекрашена - новый цвет {Color}");
        Console.WriteLine();
    }
}

public class GarageManager
{
    public List<Car> Garage { get; set; } = new List<Car>();

    public GarageManager()
    {

        Garage.Add(new Car("BMW M5", "Черный", 600));
        Garage.Add(new Car("Pantera", "Белый", 700));
        Garage.Add(new Car("Lada Granta", "Черный", 200));


        Garage.Add(new Car("Черный"));
    }
    
    public void ShowAllCars()
    {
        Console.WriteLine("\n Список всех машин в гараже:");

        if (Garage.Count == 0)
        {
            Console.WriteLine("Гараж пуст");
            return;
        }
    for (int i = 0; i < Garage.Count; i++)
    {
        Garage[i].Printinfo();
    }
    }
    public void AddCarToGarage (Car newcar)
    {
        if (Garage.Count >= 5)
        {
            Console.WriteLine("Гараж заполнен");
            return;
        }
        Garage.Add(newcar);
        Console.WriteLine($"Ваш {newcar.Model} был успешно добавлен в гараж");
    }
    public void TryRePaint (string? TargetModel, string? NewColor)
    {
        if (string.IsNullOrWhiteSpace(NewColor))
        {
            Console.WriteLine("Неверный цвет");
            return;
        }
        
        bool CarFound = false;

        for (int i = 0; i < Garage.Count; i++)
        {
            if (Garage[i].Model ==  TargetModel)
            {
                Garage[i].RePaint(NewColor);

                CarFound = true;
                break;
            }
        }
            if (!CarFound)
            {
                Console.WriteLine($"Машина марки {TargetModel} была не найдена");
            }
    }
}

class Pugde
{
    static void Main(string[] lox)
    {
        

        GarageManager manager = new GarageManager();




    while(true)
    {
        Console.WriteLine("1 - Показать машины в гараже");
        Console.WriteLine("2 - Добавить новую машину в гараж");
        Console.WriteLine("3 - Перекрасить машину");
        Console.WriteLine("4 - Выйти из гаража");
        string? op = Console.ReadLine();
        
    

        switch (op)
        {
            case "1":
            
            manager.ShowAllCars();
            Console.ReadKey();
            break;

            case "2":

            Console.WriteLine("Введите название новой машины");
            string? addcar = Console.ReadLine();
            if (int.TryParse(addcar, out int num) == true || string.IsNullOrWhiteSpace(addcar))
            {
                Console.WriteLine("Ошибка неверное название модели");
                Console.ReadKey();
                continue;
            }
            Console.WriteLine("Введите цвет новой машины: Черный, Желтый, Белый.");
            string? newcolor = Console.ReadLine();
            if (newcolor != "Черный" && newcolor != "Желтый" && newcolor != "Белый" )
            {
                Console.WriteLine("Такого цвета завод не производит");
                Console.ReadKey();
                continue;
            }
            Console.WriteLine("Введите силу двигателя нового машины");
            string? horsepowers = Console.ReadLine();
            if (int.TryParse(horsepowers, out int horse) == false || string.IsNullOrWhiteSpace(horsepowers) || horse < 0)
            {
                Console.WriteLine("Ошибка ввода мощности");
                Console.ReadKey();
                continue;
            }
            Car userCar = new Car(addcar, newcolor, horse);
            manager.AddCarToGarage(userCar);
            Console.ReadKey();
            continue;

            case "3":
            Console.WriteLine("Цех покраски");
            Console.WriteLine("Выберите машину, которую хотите перекрасить");

            string? carModel = Console.ReadLine();
            
            Console.WriteLine("Введите желаемый цвет для покраски");

            string? NewColor = Console.ReadLine();

            manager.TryRePaint(carModel, NewColor);

            Console.ReadKey();
            break;

            
            case "4":

            Console.WriteLine("Выход");
            return;

        }
    }
    }


}
