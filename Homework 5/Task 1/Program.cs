using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Володин Артем

//1. Создать программу, которая будет проверять корректность ввода логина.
//Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского 
//алфавита или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите логин: ");
            string UserLogin = Console.ReadLine();
            bool check = true;

            Console.Write("Проверка без регулярных выражений: ");
            if (UserLogin.Length < 2 | UserLogin.Length > 10)//проверка длины
            {
                Console.WriteLine("логин неподходящей длины (должен быть от 2 до 10 символов)");
            }
            else
            {
                char[] Login = UserLogin.ToCharArray();
                if (char.IsDigit(Login[0]))//проверка первого символа
                {
                    Console.WriteLine("логин не должен начинаться с числа");
                }
                else
                {
                    for (int i = 0; i < Login.Length; i++)
                    {
                        char b = char.ToLower(Login[i]);
                        if(char.IsLetterOrDigit(b) != true | (b <= 'a' | b >= 'z'))//проверка остальных символов
                        {
                            check = false;
                            Console.WriteLine("логин содержит недопустимые символы");
                            break;
                        }
                    }
                }
            }

            if (check == true)
            {
                Console.WriteLine("Логин хороший");
            }

            Console.ReadLine();

        }
    }
}
