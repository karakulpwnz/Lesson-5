using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Володин Артем

//4. Задача ЕГЭ.
//*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
//школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не
//превосходит 100, каждая из следующих N строк имеет следующий формат:
//<Фамилия> <Имя> <оценки>,
//где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
//более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
//пятибалльной системе. <Фамилия> и<Имя>, а также <Имя> и<оценки> разделены одним пробелом.
//Пример входной строки:
//Иванов Петр 4 5 3
//Требуется написать как можно более эффективную программу, которая будет выводить на экран
//фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
//набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
//Достаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в
//начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения
//задач используйте неизменяемые строки (string)


namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = new List<string>();
            StreamReader file = new StreamReader("..\\..\\results.txt");
            string input = null;
            while ((input = file.ReadLine()) != null)
            {
                text.Add(input);
            }//считал файл в список строк

            Console.WriteLine("Исходный список: ");
            for (int i = 0; i < text.Count; i++)
            {
                Console.WriteLine(text[i]);
            }
            int count = Convert.ToInt32(text[0]);
            text.RemoveAt(0);//убрал из списка строку с количеством

            string[] names = new string[12];//массив с именами
            double[,] marks = new double[12, 4];//массив с оценками и средним значением
            for(int i = 0; i < 12; i++)//конвертирую список в массивы
            {
                int spacecounter = 0;
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (text[i][j] == ' ')
                    {
                        spacecounter++;
                    }
                    else if (spacecounter < 2)
                    {
                        names[i] = names[i] + text[i][j];
                    }
                    else if (spacecounter == 2)
                    {
                        string x = Convert.ToString(text[i][j]);
                        marks[i, 0] = Convert.ToDouble(x);
                    }
                    else if (spacecounter == 3)
                    {
                        string y = Convert.ToString(text[i][j]);
                        marks[i, 1] = Convert.ToDouble(y);
                    }
                    else if (spacecounter == 4)
                    {
                        string z = Convert.ToString(text[i][j]);
                        marks[i, 2] = Convert.ToDouble(z);
                        marks[i, 3] = Math.Round(((marks[i, 0] + marks[i, 1] + marks[i, 2]) / 3),2);
                    }
                }
            }

            double[,] temp = new double[12, 2];//создаю вспомогательный массив. в массив перенес среднюю оценку и порядковый номер ученика.
            for (int i = 0; i < 12; i++)
            {
                temp[i, 0] = i;
                temp[i, 1] = marks[i, 3];
            }

            //Console.WriteLine("Номера и оценки:");//вывод вспомогательного массива

            //for (int i = 0; i < 12; i++)
            //{
            //    Console.WriteLine(temp[i, 0] + " " + temp[i, 1] + "\n");
            //}

            double[,] t = new double[1,2];//сортировка вспомогательного массива отменьшего к большему по средней оценке
            for(int i = 0; i < 11; i++)
            {
                for(int j = i + 1; j < 12; j++)
                {
                    if (temp[i, 1] > temp[j, 1])
                    {
                        t[0, 0] = temp[i, 0];
                        temp[i, 0] = temp[j, 0];
                        temp[j, 0] = t[0, 0];

                        t[0, 1] = temp[i, 1];
                        temp[i, 1] = temp[j, 1];
                        temp[j, 1] = t[0, 1];
                    }
                }
            }

            //Console.WriteLine("Сортированные номера и оценки:");//вывод отсортированного вспомогательного массива

            //for (int i = 0; i < 12; i++)
            //{
            //    Console.WriteLine(temp[i, 0] + " " + temp[i, 1] + "\n");
            //}

            Console.WriteLine("1. " + names[Convert.ToInt32(temp[0, 0])]);
            Console.WriteLine("2. " + names[Convert.ToInt32(temp[1, 0])]);
            Console.WriteLine("3. " + names[Convert.ToInt32(temp[2, 0])]);//вывод имен первых трех учеников

            int count1 = 3;
            for(int i = 0; i < 12; i++)//вывод тех учеников, кто не вошел в первые три, но чей средний балл совпадает со средним баллом третьего места
            {
                if(marks[i,3] == temp[2, 1] & i != Convert.ToInt32(temp[0, 0]) & i != Convert.ToInt32(temp[1, 0]) & i != Convert.ToInt32(temp[2, 0]))
                {
                    count1++;
                    Console.WriteLine(count1 + ". " + names[i]);
                }
            }

            //Console.WriteLine("Имена:");//вывод имен

            //for (int i = 0; i < 12; i++)
            //{
            //    Console.WriteLine(names[i] + "\n");
            //}

            //Console.WriteLine("Оценки:");//вывод оценок

            //for (int i = 0; i < 12; i++)
            //{
            //    Console.WriteLine(marks[i, 0] + " " + marks[i, 1] + " " + marks[i, 2] + " " + marks[i, 3] + "\n");
            //}

            Console.ReadLine();
        }
    }
}
