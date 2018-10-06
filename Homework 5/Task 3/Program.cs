using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Володин Артем

//3. * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.Регистр можно не учитывать:
//а) с использованием методов C#;
//б) * разработав собственный алгоритм.
// Например:
//badc являются перестановкой abcd.


namespace Task_3
{
    class Program
    {
        static string ReplaceCustom(string UserFirst, string UserSecond)//в своем методе использовал посимвольное сравнение строк
        {
            if (UserFirst == UserSecond)
            {
                return "Перестановка";
            }

            StringBuilder first = new StringBuilder(UserFirst);
            StringBuilder second = new StringBuilder(UserSecond);

            bool flag = false;

            for (int i = 0; i < first.Length; i++)//идем по символам 1 строки
            {
                if (flag)//был ли удален хотя бы 1 символ первой строки
                {
                    i = 0;
                }

                if (first.Length != second.Length)//если неравные длины, то сразу выходим из цикла
                {
                    break;
                }

                for (int j = 0; j < second.Length; j++)//идем по символам 2 строки
                {
                    if (first[i] == second[j])
                    {
                        first.Remove(i, 1);
                        second.Remove(j, 1);
                        j = -1;
                        flag = true;
                    }
                }
            }

            if (first.ToString() == second.ToString())
            {
                return "Перестановка";
            }
            else
            {
                return "Не перестановка";
            }
        }

        static string ReplaceSystem(string UserFirst, string UserSecond)//в системном методе использовал сортировку строк и их сравнение
        {
            UserFirst = string.Concat(UserFirst.OrderBy(x => x).ToArray());
            UserSecond = string.Concat(UserSecond.OrderBy(x => x).ToArray());


            if (UserFirst == UserSecond)
            {
                return "Перестановка";
            }
            else
            {
                return "Не перестановка";
            }
        }

        static void Main(string[] args)
        {
            string first = "qiuop";
            string second = "pqiuo";

            Console.WriteLine("Первая строка: " + first);
            Console.WriteLine("Вторая строка: " + second);

            Console.WriteLine("\nСобственный метод: " + ReplaceCustom(first, second));

            Console.WriteLine("\nСистемный метод: " + ReplaceSystem(first, second));


            Console.ReadLine();
        }
    }
}
