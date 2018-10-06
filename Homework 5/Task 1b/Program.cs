using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Володин Артем

//1. Создать программу, которая будет проверять корректность ввода логина.
//Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского 
//алфавита или цифры, при этом цифра не может быть первой:
//б) с использованием регулярных выражений.

namespace Task_1b
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Логин должен состоять из цифр и букв латинского алфавита." +
                "\nНе может начинаться с цифры, не может быть короче 2 и длиннее 10 символов." +
                "\nВведите логин: ");
            string UserLogin = Console.ReadLine();

            Regex regex = new Regex("[a-zA-Z]{1}[a-zA-Z0-9]{1,9}");
            Match match = regex.Match(UserLogin);

            if (match.Value == UserLogin)
            {
                Console.WriteLine("логин хороший");
            }
            else
            {
                Console.WriteLine("логин не подходит под условия");
            }

            Console.ReadLine();

        }
    }
}
