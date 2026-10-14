using System.Buffers;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace c_larp;

public class BankClient
{
    public string? Name {get; private set;}
    public double Balance {get; private set;}
    public bool Block {get; private set;}
    public int FaildTry {get; private set;}
    public string? CardType {get; private set;} // gold, silver, platinum, base


    public BankClient(string? name, double balance, bool block, int faildtry, string? cardtype)
    {
        Name = name;
        Balance = balance;
        Block = block;
        FaildTry = faildtry;
        CardType = cardtype;
    }
}

public class BankSystem
{
    private List<BankClient> _bankClients = new List<BankClient>()
    {
        new BankClient("Alexey", 7000, false, 0, "platinum"),
        new BankClient("Stive", 100000, false, 0, "platinum"),
        new BankClient("Misha", 2000000000, true, 3, "silver"),
        new BankClient("Artem", 1500, false, 2, "gold"),
        new BankClient("Myrebit", 0, true, 3, "base")
    };

    public void ShowAllVipClients()
    {
        Console.WriteLine("Вывод вип клиентов");

        List<BankClient> vip = _bankClients.Where(c => c.Block == false && (c.CardType == "platinum" || c.CardType == "gold")).OrderByDescending(c => c.Balance).ToList();


        foreach(BankClient client in vip)
        {
            Console.WriteLine($"{client}");
        }
    }

    public void Checksecurityalert()
    {
        Console.WriteLine("Сканирование банковской системы на ошибки ввода пинкода");

        bool SecuriteAlertPinAttemp = _bankClients.Any(c =>c.Block == false && c.FaildTry == 2 );

        if (SecuriteAlertPinAttemp)
        {
            Console.WriteLine($"лимит ввода был превышен");
        }
        else
        {
            Console.WriteLine("Пин код был успешно введен");
        }
    }

    public void Getfullmoney()
    {
        Console.WriteLine("Подсчет денежных средств на всех картах");
        Thread.Sleep(1000);

        double Doubtfullmoney = _bankClients.Where(c => c.Block == true).Sum(c => c.Balance);

        Console.WriteLine($"Общая сумма замороженная на заблокированых картах{Doubtfullmoney}");
    }
    
}

class Programm
{
    static void Main(string[] args)
    {
        BankSystem system = new BankSystem();


        while (true)
        {

        }

    }
}