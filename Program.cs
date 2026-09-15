using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
        while(true) // калькулятор не надо постоянно запускать
    {
      Console.WriteLine("Введите первое число: ");
      string? input = Console.ReadLine(); //Считывает что ввели на клавиатуре

      if (double.TryParse(input, CultureInfo.InvariantCulture, out double num1) == false) // условие для перевода ищ текста в число, при вводе буквы ошибка (==false), out int создание переменной на лету
    {
        
        Console.WriteLine("ошибка - текст не является числом. Попробуйте снова.");
        Console.ReadKey(); //  ждем нажатия кнопки возращаем принудельно в начало цикла while

        continue;  //  принудительный возврат программы в начало цикла while
    
    }
    Console.WriteLine("введите математический знак:(+, -, *, /, exit) ");
    string? op = Console.ReadLine();
    if (op == "exit")
    {
        break;

    }
    Console.WriteLine("Введите второе число: ");
    string? input2 = Console.ReadLine();
    
    if (double.TryParse(input2, CultureInfo.InvariantCulture, out double num2) == false)
    {
        Console.WriteLine("ошибка - текст не является числом. Попробуйте снова.");
        Console.ReadKey();

        continue;

    }


double result = 0;
double finalresult = 0; // hotkey crtl + alt  и стрелочки перенос выделенной строки через стрелочки вверх вниз

result = Bander(num1, num2 ,op);




    if (op == "/" && num2 == 0 )      
    {
        Console.WriteLine("на 0 нельзя делить");
        Console.ReadKey();

        continue;
    }       
    Console.WriteLine("введите второй математический знак /, +, -, *, exit- для выхода с программы");
    string? op2 = Console.ReadLine();
    if (op2 == "exit")
    {
        break;
    }

    Console.WriteLine("введите третье число");
    string? number3 = Console.ReadLine();

    if (double.TryParse(number3, CultureInfo.InvariantCulture, out double num3) == false)
    {
        Console.WriteLine("ошибка - текст не является числом");
        Console.ReadKey();
        continue;
       
    }
     if (num3 == 0 && op2 == "/")
        {
            Console.WriteLine("на 0 делить нельзя");
            Console.ReadKey();
            continue;
        }

    // hotkey alt + нижняя стрелочка перенос выделенной строки через стрелочки вверх вниз
                   finalresult = Bander(result, num3, op2); // вызов изолированого метода

    Console.WriteLine($"у нас получилось: {finalresult}");
    Console.WriteLine($"нажмите любую кнопку");
    Console.ReadKey();
   }
   }
   static double Bander(double a, double b, string? op) //сделал изолированый метод
   {
        double result = 0;
        switch (op) // сделал код компактнее, знакомство с оператором свитч и его частью кейс (также был дефолт)
        {
            case "+": result = a + b; break;
            case "-": result = a - b; break;
            case "*": result = a * b; break;
            case "/":
            if (b != 0) result = a / b; break;

        }
        return result;
   }

   }

             
