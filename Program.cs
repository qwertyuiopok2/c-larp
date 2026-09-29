using System.Collections;
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
class Pugde
{
    static void Main(string[] lox)
    {
        List<Car> Garage = new List<Car>();

        Garage.Add(new Car("BMW M5", "Черный", 600));
        Garage.Add(new Car("Pantera", "Белый", 700));
        Garage.Add(new Car("Lada Granta", "Черный", 200));
        Garage.Add(new Car("BOOM", "Белый", 500));


        Garage.Add(new Car("Черный")); // компьютер просматривает наши конструкторы в отдельном классе и выбирает подходящий по условиям (1 строка требует заполнения, а остальные заполняются автоматически по контструктору)




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
            for(int i = 0; i < Garage.Count; i++)
            {
                Garage[i].Printinfo();
            }

            break;

            case "2":
            if (Garage.Count == 5)
            {
                Console.WriteLine("В гараже закончилось место");
                Console.ReadKey();
                break;
            }
            Console.WriteLine("Введите модель новой машины");
            string? newmodel = Console.ReadLine();
            if (newmodel == null)
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                break;
            }
            Console.WriteLine("Введите цвет новой машины");
            string? newcolor = Console.ReadLine();
            if (newcolor == null)
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                break; 
            }
            Console.WriteLine("Введите мощность новой машины (в лошадиных силах)");
            string? newpower = Console.ReadLine();
            if(int.TryParse(newpower, out int num1) == false || num1 <= 0)
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                break;
            }
            else
            {
            Garage.Add(new Car(newmodel, newcolor, num1));
            Console.WriteLine("Машина добавлена");
            }
            for(int i = 0; i < Garage.Count; i++)
            {
                Console.WriteLine($"МАШИНА Модель - {Garage[i].Model}, Цвет - {Garage[i].Color}, Пробег - {Garage[i].Horespower}");
            }           
            break;
            case "3":
            Console.WriteLine("Введите модель машины в которую хотите перекрасить");
            string? target = Console.ReadLine();
            bool carfound = false;
            
            for(int i = 0; i < Garage.Count; i++)
            {
                if (Garage[i].Model == target)
                {
                    Console.WriteLine($"В какой цвет хотите перекрасить машину {Garage[i].Model}");
                    string? usercolor = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(usercolor))
                    {
                        Console.WriteLine("Строка не может быть пустой");
                        Console.ReadKey();
                        break;
                    }

                    Garage[i].RePaint(usercolor);

                    carfound = true;
                    Console.ReadKey();
                    break;
                }
            }
            if (!carfound)
            {
                Console.WriteLine("Ошибка машина не найдена");
                Console.ReadKey();
            }
            break;

            case "4":
            Console.WriteLine("Нажмите любую кнопку чтобы выйти с гаража");
            Console.ReadKey();
            return;

        }
    }
    }


}
