using System.Buffers.Binary;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks.Dataflow;
using System.Threading.Tasks.Sources;
using Microsoft.VisualBasic;

namespace c_larp;

public class Book
{
    public string? Bookname {get; private set; }
    public string? Authorsname {get; private set; }
    public int Stranici {get; private set; }
    public bool Vidana {get; set; }



    public Book (string? name, string? authorsname, int stranici)
    {
        Bookname = name;
        Authorsname = authorsname;
        Stranici = stranici;

        Vidana = false;
    }

    public void printallbooks()
    {
        string? vidana;                                   
        if (Vidana == true)
        {
            vidana = "на руках";
        }
        else
        {
            vidana = "на полке";
        }

        Console.WriteLine($"Книга {Bookname}, Автора {Authorsname}, с количеством {Stranici} страниц, сейчас она {vidana}");
    }
}



public class LiblaryManager
{
    List<Book> Liblary {get; set;} = new List<Book>();

    public LiblaryManager()
    {
        Liblary.Add(new Book("Мастер и Маргарита", "М.Булгаков", 448));
        Liblary.Add(new Book("Капитанская дочка", "А.Пушкин", 160));
    }

    public void Showallbooks()
    {
        Console.WriteLine("Библиотека");

        if (Liblary.Count >= 150)
        {
            Console.WriteLine("Ошибка библиотека переполнена");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < Liblary.Count; i++)
        {
            Liblary[i].printallbooks();
        }
    }

    public bool dublicate (string? newnamebook)
    {
        for (int i = 0; i < Liblary.Count; i++)
        {
            if (Liblary[i].Bookname == newnamebook)
            {
                Console.WriteLine("Такая книга уже существует");
                return true;
            }
        }
        return false;
    }
    public bool publicate (string? newnamebook)
    {
        for (int i = 0; i < Liblary.Count; i++)
        {
            if (Liblary[i].Bookname == newnamebook)
            {
                Console.WriteLine("Книга найдена");
                Liblary[i].Vidana = true;
                return false;
            }           
        }
        Console.WriteLine("Книга не найдена");
        return true;      
    }

    
    public bool addnewbook(Book newbook)
    {
        if (Liblary.Count >= 5)
        {
            Console.WriteLine("Библиотека заполнена");
            return true;
        }
        Liblary.Add(newbook);
        return false;
    }
}

class Pudge
{
    static void Main()
    {
        LiblaryManager manager = new LiblaryManager();

        while (true)
        {
            Console.WriteLine("1 - Показать все книги");
            Console.WriteLine("2 -  Добавить книгу");
            Console.WriteLine("3 - Выдать книгу читателю");
            Console.WriteLine("4 - Выход с библиотеки");

            string? op = Console.ReadLine();


            switch (op)
            {
                case "1":
                Console.WriteLine("Библиотека");
                manager.Showallbooks();
                continue;

                case "2":
                Console.WriteLine("Введите название книги, которую хотите добавить");
                string? newbookname = Console.ReadLine();
                if (int.TryParse(newbookname, out int num1) == true || string.IsNullOrWhiteSpace(newbookname))
                {
                    Console.WriteLine("Неверное название книги");
                    Console.ReadKey();
                    continue;
                }
                manager.dublicate(newbookname);
                Console.WriteLine("Введите автора книги");
                 string? newavtor = Console.ReadLine();
                if (int.TryParse(newavtor, out int num2) == true || string.IsNullOrWhiteSpace(newbookname))
                {
                    Console.WriteLine("Неверное имя автора");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("Введите количество страниц в книге");
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int num3) == false || string.IsNullOrWhiteSpace(s))
                {
                    Console.WriteLine("Неверно введено количество страниц");
                    Console.ReadKey();
                    continue;
                }
                Book newbook = new Book(newbookname, newavtor, num3);
                manager.addnewbook(newbook);
                Console.ReadKey();
                break;
                case "3":

                Console.WriteLine("Напишите название книги, которую хотите взять");
                string? ekipbook = Console.ReadLine();
                 if (int.TryParse(ekipbook, out int nu) == true || string.IsNullOrWhiteSpace(ekipbook))
                {
                    Console.WriteLine("Неверное название книги");
                    Console.ReadKey();
                    continue;
                }
                manager.publicate(ekipbook);
                break;
                case "4":
                Console.WriteLine("Выход из библиотеки");
                return;
            }
        }
    }
}


