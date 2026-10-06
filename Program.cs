namespace c_larp;

public class Card
{
    public string? Cnamber { get; private set; }
    public string? OwnerCard { get; private set; }



    private decimal _cardBalance;
    private string? _pincode;

    private int _failedpin = 0;
    private bool _isblock = false;

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
        if (_isblock)
        {
            Console.WriteLine("Ошибка ваша карта заблокирована");
            Console.ReadKey();
            return;
        }
        if (inputPin == _pincode)
        {
            Console.WriteLine("Авторизация успешна");
            Console.WriteLine($"Ваш баланс = {_cardBalance} рублей");
        }
        else
        {
            _failedpin++;
            Console.WriteLine("Ошбика авторицазии : неверный пинкод");
            if(_failedpin ==3)
            {
                _isblock = true;
            }
        }
    } 
    public bool Isblocked
    {
        get {return _isblock;} 
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
        if (_isblock)
        {
            return false;
        }
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
    public bool Pincodechek2 (string? pin)
    {
        if (_isblock)
        {
            return false;
        }
        if (pin == _pincode)
        {
            _failedpin = 0;
            return true;
        }
        else
        {
            _failedpin++;
            if (_failedpin == 3)
            {
                _isblock = true;
            }
            return false;
        }
    }
    public bool Changepin (string? oldpin, string? newpin)
    {
        if (_isblock)
        {
            return false;
        }
        if (oldpin != _pincode)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(newpin) || newpin.Length != 4|| int.TryParse(newpin,out int io) == false)
        {
            return false;
        }
        if (_pincode == newpin)
        {
            return false;
        }
        _pincode = newpin;
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
            if (myCard.Isblocked == true)
            {
                Console.WriteLine("Карта заблокирована");
                return;
            }
            Console.WriteLine("Меню банка");
            Console.WriteLine("1 - Проверить баланс карты");
            Console.WriteLine("2 - Пополнить карту");
            Console.WriteLine("3 - Снять деньги с карты");
            Console.WriteLine("4 - Сменить пинкод");
            Console.WriteLine("5 - Выйти");
            Console.WriteLine("Выберите действие");

            string? op = Console.ReadLine();

            switch (op)
            {
                case "1":

                    if (myCard.Isblocked == true)
                    {
                        Console.WriteLine("Карта заблокирована");
                    }
                    Console.WriteLine("Введите четырех значный код");
                    string? userpin = ReadSecretPin();

                    myCard.CheckBalanse(userpin);
                    Console.ReadKey();
                    break;

                case "2":

                    Console.WriteLine("Пополнения счета");
                    Console.WriteLine("Введите пинкод");
                    string? code = ReadSecretPin();
                    if (int.TryParse(code, out int num5) == false || string.IsNullOrWhiteSpace(code))
                    {
                        Console.WriteLine("Пинкод введен не корректно");
                    }
                    if (!myCard.Pincodechek2(code))
                    {
                        if (myCard.Isblocked)
                        {
                            Console.WriteLine("Ваша карта заблокирована");
                        }
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
                    string? pin = ReadSecretPin();

                    if (int.TryParse(pin, out int num2) == false || string.IsNullOrWhiteSpace(pin))
                    {
                        Console.WriteLine("Пинкод введен не верно");
                        Console.ReadKey();
                        continue;
                    }
                    if (!myCard.Pincodechek2(pin))
                    {
                        if (myCard.Isblocked)
                        {
                            Console.WriteLine("Ваша карта заблокирована");
                            break;
                        }
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
                {
                Console.WriteLine("Введите пинкод");
                string? oldpin = ReadSecretPin();
                Console.WriteLine("Введите новый пинкод");
                string? newpin = ReadSecretPin();
                if (myCard.Changepin(oldpin, newpin) == false)
                {
                    Console.WriteLine("Ошибка не удалось сменить пинкод");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("Вы успешно сменили пинкод");
                Console.ReadKey();
                break;
                }
                case "5":

                    Console.WriteLine("Выход");
                    Console.WriteLine("Заберите карту");
                    return;
            }
        }
    }
    static string ReadSecretPin()
    {
        string pin = "";    // Сейф куда записывается пин-код

        while (true)
        {
            // Перехват клавиши без вывода на экран
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Enter)    // Если пользователь нажал enter он закончил вводить пин
            {
                Console.WriteLine();    // Перевод строки на новую строку в консоли
                break; // Выход из бесконечного списка
            }
            // Обработка клавиши Backspase (Стирание)
            //Если пользователь нажал стереть при том что ошибся и в его (нашем) и в его (или у нас) уже есть буквы

            if (keyInfo.Key == ConsoleKey.Backspace && pin.Length > 0)
            {
                pin = pin.Substring(0, pin.Length - 1);     // Удаление самого последнего символа из памяти в нашей строке  
                //Главный трюк со стиранием с экрана
                // \b - Возращение курсора на 1 шаг назад
                // Пробел - зачистка старой звездочки пустотой
                // \b - сново возвращает курсор назад чтобы новый символ стал на пустое место 
                Console.WriteLine("\b \b");
            }
            // Проверка ввода нажатия имменно текстовой клавиши (цифры / буквы) вместо shift, ctrl, Alt, esc.
            else if(!char.IsControl(keyInfo.KeyChar))
            {
                pin += keyInfo.KeyChar; // Добавление реального символа в наш сейф текста pin
                Console.Write("*"); // Замена текста с невидимых букв на звездочки обманки на экран
            }
        }
        return pin; // Возращаем полностью секретный пин-код
    }
}