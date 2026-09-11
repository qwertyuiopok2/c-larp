using System;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
        while(true) // калькулятор не надо постоянно запускать
    {
      Console.WriteLine("Введите первое число: ");
      string? input = Console.ReadLine(); //Считывает что ввели на клавиатуре

      if (int.TryParse(input, out int num1) == false) // условие для перевода ищ текста в число, при вводе буквы ошибка (==false), out int создание переменной на лету
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
    
    if (int.TryParse(input2, out int num2) == false)
    {
        Console.WriteLine("ошибка - текст не является числом. Попробуйте снова.");
        Console.ReadKey();

        continue;

    }
    // hotkey alt + нижняя стрелочка перенос выделенной строки через стрелочки вверх вниз
                    int result = 0; // hotkey crtl + alt  и стрелочки перенос выделенной строки через стрелочки вверх вниз
                    switch (op)
                    {
                        case "+": result = num1 + num2; break;
                        case "*": result = num1 * num2; break;
                        case "-": result = num1 - num2; break;
                        case "/": 
                        if (num2 == 0)
                        {
                            Console.WriteLine("ошибка на 0 делить нельзя");
                            Console.ReadKey();
                            continue; 
                        }
                        result = num1 / num2; break;
            
                    }

    Console.WriteLine($"у нас получилось: {result}");
    Console.WriteLine($"нажмите любую кнопку");
    Console.ReadKey();
   }
   }
            // if (op == "+")
            // {

            // result = num1 + num2;

            // }
            // else if (op == "-")
            // {

            // result = num1 - num2;

            // }
            // else if (op == "*")
            // {

            // result = num1 * num2;

            // }
            // else if (op == "/")
            // {

            // result = num1 / num2;

            // }
   }