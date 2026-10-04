using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Xml;

namespace c_larp;

public class Card
{
    public string? Cnamber { get; private set; }
    public string? OwnerCard { get; private set; }



    private decimal _cardBalance;
    private string? _pincode;


    public Card (string cnamber, string ownercard, string pincode, decimal cardbalance)
    {
        Cnamber = cnamber;
        OwnerCard = ownercard;
        _pincode = pincode;

        if (cardbalance < 0)
        {
            _cardBalance = 0;
        }
        else
        {
            _cardBalance = cardbalance;
        }
    }

    public void CheckBalanse(string? inputPin)
    {
        if (inputPin == _pincode)
        {
            Console.WriteLine("Авторизация успешна");
            Console.WriteLine($"Ваш баланс = {_cardBalance} рублей");
        }
        else
        {
            Console.WriteLine("Ошбика авторицазии : неверный пинкод");
        }
    } 
    public void DepositMoney (decimal Balance)
    {
        if (Balance <= 0)
        {
            Console.WriteLine("Сумма пополнения должна быть больше нуля");
            return;
        }
        
        _cardBalance += Balance;
        Console.WriteLine($"Счет успешно пополнен ваш текущий счет равен {_cardBalance} руб");
    }
    public bool DrowMoney (decimal clearmoney)
    {
        if (clearmoney <= 0)
        {
            return false;
        }
        else if (clearmoney > _cardBalance)
        {
            return false;
        }

        _cardBalance -= clearmoney;
        return true;
    }
    public bool Pincodcheck (string? pin)
    {
        if (pin != _pincode)
        {
            return false;
        }
        return true;
    }
}



class Program
{
    static void Main ()
    {
        Card myCard = new Card("4267 8923 3125 0976", "Артур", "1111", 500);

        
        while (true)
        {
            Console.WriteLine("Меню банка");
            Console.WriteLine("1 - Проверить баланс карты");
            Console.WriteLine("2 - Пополнить карту");
            Console.WriteLine("3 - Снять деньги с карты");
            Console.WriteLine("4 - Выйти");
            Console.WriteLine("Выберите действие");

            string? op = Console.ReadLine();

            switch (op)
            {
                case "1":

                    Console.WriteLine("Введите четырех значный код");
                    string? userpin = Console.ReadLine();

                    myCard.CheckBalanse(userpin);
                    Console.ReadKey();
                    break;

                case "2":

                    Console.WriteLine("Пополнения счета");
                    Console.WriteLine("Введите пинкод");
                    string? code = Console.ReadLine();
                    if (int.TryParse(code, out int num5) == false || string.IsNullOrWhiteSpace(code))
                    {
                        Console.WriteLine("Пинкод введен не корректно");
                    }
                    if (!myCard.Pincodcheck(code))
                    {
                        Console.WriteLine("Пинкод не подходит");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Вы авторизовались");
                    Console.WriteLine("Введите сколько хотите пополнить");

                    string? input = Console.ReadLine();

                    if (decimal.TryParse(input, out decimal num1) == false || string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Число введено неккоректно");
                        Console.ReadKey();
                        continue;
                    }
                    myCard.DepositMoney(num1);
                    Console.ReadKey();
                    break;
                    
                case "3":
                    Console.WriteLine("Снятие денег");
                    Console.WriteLine("Введите пинкод");
                    string? pin = Console.ReadLine();

                    if (int.TryParse(pin, out int num2) == false || string.IsNullOrWhiteSpace(pin))
                    {
                        Console.WriteLine("Пинкод введен не верно");
                        Console.ReadKey();
                        continue;
                    }
                    if (!myCard.Pincodcheck(pin))
                    {
                        Console.WriteLine("Вы не авторизовались пинкод не верен");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Вы авторизовались");

                    Console.WriteLine("Введите сумму денег для снятия");
                    string? clmoney = Console.ReadLine();

                    if (decimal.TryParse(clmoney, out decimal num3) == false || string.IsNullOrWhiteSpace(clmoney))
                    {
                        Console.WriteLine("Число для снятия денег введено не верно");
                        Console.ReadKey();
                        continue;
                    }
                    if (!myCard.DrowMoney(num3))
                    {
                        Console.WriteLine("Недостаточно средств или введена не корректная сумма");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                    Console.WriteLine("Ваши деньги успешно списаны");
                    break;
                    }

                case "4":

                    Console.WriteLine("Выход");
                    Console.WriteLine("Заберите карту");
                    return;
            }
        }
    }
}
