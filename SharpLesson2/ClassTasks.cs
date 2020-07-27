using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLesson2
{
    class ClassTasks
    {
        private ClassVisual v = new ClassVisual();
        private int GetIntNumberFromScreen()
        {
            string line = Console.ReadLine();
            if (line.Contains('.'))
                line = line.Replace(".", ",");

            float a = float.Parse(line);

            return (int)Math.Round(a);
        }

        /*
         * Задание 1
         * Ввести с консоли N чисел. Вывести сумму, максимальное, минимальное значения, количество четных чисел, произведение нечетных чисел.
         */
        public void Task1()
        {
            while (true)
            {
                v.TaskText("Задание 1.", "Ввести с консоли N чисел.\nВывести сумму, максимальное, минимальное значения, количество четных чисел, произведение нечетных чисел.");

                try
                {
                    //тк это задание дано до массивов, 
                    //то я так поняла, что его надо решить без использования массивов

                    v.TaskExtraText("Введите число a: ");
                    int a = GetIntNumberFromScreen();

                    v.TaskExtraText("Введите число b: ");
                    int b = GetIntNumberFromScreen();

                    v.TaskExtraText("Введите число c: ");
                    int c = GetIntNumberFromScreen();

                    v.TaskExtraText("Введите число d: ");
                    int d = GetIntNumberFromScreen();

                    v.TaskExtraText("Введите число e: ");
                    int e = GetIntNumberFromScreen();

                    //сумма
                    int sum = a + b + c + d + e;

                    //ищем маскимальное
                    int max = 0;
                    max = (max < a) ? a : max;
                    max = (max < b) ? b : max;
                    max = (max < c) ? c : max;
                    max = (max < d) ? d : max;
                    max = (max < e) ? e : max;

                    //ищем мнимальное
                    int min = 0;
                    min = (min > a) ? a : min;
                    min = (min > b) ? b : min;
                    min = (min > c) ? c : min;
                    min = (min > d) ? d : min;
                    min = (min > e) ? e : min;

                    //количество четных чисел
                    int i = 0;
                    i = ((a % 2 == 0) ? 1 : 0) +
                        ((b % 2 == 0) ? 1 : 0) +
                        ((c % 2 == 0) ? 1 : 0) +
                        ((d % 2 == 0) ? 1 : 0) +
                        ((e % 2 == 0) ? 1 : 0);

                    //произведение нечетных чисел
                    int j = 1;
                    j = ((a % 2 == 0) ? 1 : a) *
                        ((b % 2 == 0) ? 1 : b) *
                        ((c % 2 == 0) ? 1 : c) *
                        ((d % 2 == 0) ? 1 : d) *
                        ((e % 2 == 0) ? 1 : e);

                    v.TaskResult("\n Сумма "+sum.ToString()
                        +",\n Максимальное "+max.ToString()
                        +",\n Минимальное"+min.ToString()
                        +",\n Количество четных чисел "+i.ToString()
                        +",\n Произведение нечетных чисел "+j.ToString());

                    break;
                }
                catch (Exception e)
                {
                    v.TaskWarning(e.Message.ToString());
                    continue;
                }
            }
        }


        /*
         * Задание 2
         * Заполнить с консоли массив из N элементов. Отсортировать. Вывести результат. N - задается с консоли
         */
        public void Task2()
        {
            while (true)
            {
                v.TaskText("Задание 2.", "Заполнить с консоли массив из N элементов. \nОтсортировать. Вывести результат. N - задается с консоли");

                try
                {
                    v.TaskExtraText("Введите число N: ");
                    int n = GetIntNumberFromScreen();

                    int[] array = new int[n];
                    v.TaskExtraText("Заполняем массив: ");
                    for (int i = 0; i < n; i++)
                    {
                        v.TaskExtraText("Введите число: ");
                        array[i] = GetIntNumberFromScreen();
                    }

                    // Instantiate the reverse comparer.
                    IComparer revComparer = new ReverseComparer();
                    Array.Sort(array, revComparer);

                    string res = "";
                    for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0);  i++)
                    {
                        res += array[i]+", ";
                    }

                    res = res.Trim().Trim(',');

                    v.TaskResult(res);

                    break;
                }
                catch (Exception e)
                {
                    v.TaskWarning(e.Message.ToString());
                    continue;
                }
            }
        }

        public class ReverseComparer : IComparer
        {
            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            public int Compare(Object x, Object y)
            {
                return (new CaseInsensitiveComparer()).Compare(y, x);
            }
        }

        /*
         * Задание 3 
         * Заполнить 2 матрицы размерности NxN случайными числами. Вывести на консоль. Сложить 2 матрицы. Вывести результат.
         * Класс Random для генерации случаных чисел.
         */
        public void Task3()
        {
            while (true)
            {
                v.TaskText("Задание 3.", "Заполнить 2 матрицы размерности NxN случайными числами. Вывести на консоль. Сложить 2 матрицы. Вывести результат.");
                try
                {
                    v.TaskExtraText("Введите число N: ");
                    int n = GetIntNumberFromScreen();

                    var rand = new Random();

                    //матрица 1
                    int[,] arr1 = new int[n, n];
                    int[,] arr2 = new int[n, n];
                    int[,] summ = new int[n, n];
                    string res = "";
                    for (int i = arr1.GetLowerBound(0); i <= arr1.GetUpperBound(0); i++)
                    {
                        string s1 = "", s2="";
                        for (int j = arr1.GetLowerBound(1); j <= arr1.GetUpperBound(1); j++)
                        {
                            arr1[i, j] = rand.Next(0,9);
                            arr2[i, j] = rand.Next(10,30);

                            s1 += arr1[i, j].ToString() + " ";
                            s2 += arr2[i, j].ToString() + " ";

                            summ[i, j] = arr1[i, j] + arr2[i, j];

                            res += summ[i, j].ToString() + " ";
                        }
                        Console.WriteLine(s1+"    "+s2);
                        res += "\n";
                    }

                    v.TaskResult("\n"+res);
                    break;
                }
                catch (Exception e)
                {
                    v.TaskWarning(e.Message.ToString());
                    continue;
                }
            }
        }

        //Домашка
        /*
         * Задание 4
         * Заполнить массив длиной N случайными числами. 
         * Ввести с консоли число A. 
         * Вывести Yes, если число A есть в массиве, No - в противном случае.
         */
        public void Task4()
        {
            while (true)
            {
                try
                {
                    break;
                }
                catch (Exception e)
                {
                    v.TaskWarning(e.Message.ToString());
                    continue;
                }
            }
        }
        /*
         * Задание 5
         * Заполнить матрицу NxM случайными числами. 
         * Из каждой строки выбрать минимальный элемент, занести его в массив. 
         * Отсортировать полученный массив и вывести его значения в обратном порядке.
         */
        public void Task5()
        {
            while (true)
            {
                try
                {
                    break;
                }
                catch (Exception e)
                {
                    v.TaskWarning(e.Message.ToString());
                    continue;
                }
            }
        }
        /*
         * Задание 6
         * Калькулятор. 
         * С консоли вводится левый операнд, операция, правый операнд. 
         * Выводится результат операции над операндами. 
         * Реализовать как минимум 4 операции, обработку ошибок (деление на 0 и др)
         */
        public void Task6()
        {
            while (true)
            {
                try
                {
                    break;
                }
                catch (Exception e)
                {
                    v.TaskWarning(e.Message.ToString());
                    continue;
                }
            }
        }
    }
}
