using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Володин Артем

//2. Разработать класс Message, содержащий следующие статические методы для обработки
//текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//Продемонстрируйте работу программы на текстовом файле с вашей программой.


namespace Task_2
{
    class Message
    {
        public static string LettersCount(int n, List<string> text)//вывод слов, которые не длинее заданного числа
        {
            string result = null;

            for(int i = 0; i < text.Count; i++)
            {
                if (text[i].Length <= n)
                    result = result + "\n" + text[i];
            }

            return result;
        }

        public static void Delete(char b, ref List<string> text)//удаление слов, оканчивающихся на заданный символ
        {

            for(int i = 0; i < text.Count; i++)
            {
                string c = text[i];
                int j = c.Length;
                if (text[i][c.Length-1] == b)
                {
                    text.RemoveAt(i);
                    i--;//так как i-ый элемент удален, цикл должен еще раз пройти по i-му элементу
                }
            }

            return;
        }

        public static string Max(List<string> text)//поиск самого длинного слова
        {
            string result = text[0];
            
            for(int i= 1; i < text.Count; i++)
            {
                if (text[i].Length > result.Length)
                {
                    result = text[i];
                }
            }
        
            return result;
        }

        public static string MaxString(List<string> text)
        {
            //string result = null;
            StringBuilder result = new StringBuilder("");
            int max = 1;

            for(int i = 0; i < text.Count; i++)
            {
                if(text[i].Length == max)
                {
                    result.Append(text[i] + "\n");
                }
                else if(text[i].Length > max)
                {
                    max = text[i].Length;
                    result.Clear();
                    result.Append(text[i] + "\n");
                }
            }


            return result.ToString();
        }

        public static string Print(List<string> text)//вывод списка
        {
            string result = null;

            for (int i = 0; i < text.Count; i++)
            {
                result = result + "\n" + text[i];
            }

            return result;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = new List<string>();
            StreamReader file = new StreamReader("..\\..\\words.txt");

            string input = null;

            while ((input = file.ReadLine()) != null)
            {
                text.Add(input);
            }

            Console.WriteLine("Исходный список: ");

            for (int i = 0; i < text.Count - 1; i++)
            {
                Console.WriteLine(text[i]);
            }

            Console.WriteLine("\nСлова длиной не более 5 символов:" + Message.LettersCount(5, text));

            Console.WriteLine("\nСамое длинное слово:\n" + Message.Max(text));

            Console.WriteLine("\nСтрока из самых длинных слов списка:\n" + Message.MaxString(text));

            Message.Delete('л', ref text);

            Console.WriteLine("\nСписок без слов, оканчивающиеся на л:" + Message.Print(text) + "\n");


            Console.ReadLine();
        }
    }
}
