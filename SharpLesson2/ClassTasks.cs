using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
                    int max = a;
                    max = (max < b) ? b : max;
                    max = (max < c) ? c : max;
                    max = (max < d) ? d : max;
                    max = (max < e) ? e : max;

                    //ищем мнимальное
                    int min = a;
                    min = (min > b) ? b : min;
                    min = (min > c) ? c : min;
                    min = (min > d) ? d : min;
                    min = (min > e) ? e : min;

                    //количество четных чисел
                    int 
                    i = ((a % 2 == 0) ? 1 : 0) +
                        ((b % 2 == 0) ? 1 : 0) +
                        ((c % 2 == 0) ? 1 : 0) +
                        ((d % 2 == 0) ? 1 : 0) +
                        ((e % 2 == 0) ? 1 : 0);

                    //произведение нечетных чисел
                    int 
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
                v.TaskText("Задание 4.", "Заполнить массив длиной N случайными числами.\nВвести с консоли число A.\nВывести Yes, если число A есть в массиве, No - в противном случае.");
                try
                {
                    v.TaskExtraText("Введите число N: ");
                    int n = GetIntNumberFromScreen();

                    // заполняем массив
                    var rand = new Random();
                    int[] arr = new int[n];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = rand.Next(-10, 10);
                        Console.Write(" {0}",arr[i].ToString());
                    }
                    
                    v.TaskExtraText("\nВведите число A: ");
                    int a = GetIntNumberFromScreen();

                    //проверяем наличие А
                    int k = Array.IndexOf(arr, a);
                    v.TaskResult(k == -1 ? "No" : "Yes");

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
                v.TaskText("Задание 5.", "Заполнить матрицу NxM случайными числами.\nз каждой строки выбрать минимальный элемент, занести его в массив.\nОтсортировать полученный массив и вывести его значения в обратном порядке.");
                try
                {
                    v.TaskExtraText("Введите число N: ");
                    int n = GetIntNumberFromScreen();
                    v.TaskExtraText("Введите число M: ");
                    int m = GetIntNumberFromScreen();

                    int[,] arr = new int[m,n];
                    int[] mins = new int[m];
                    var rand = new Random();
                    string txt ="";
                    for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                    {
                        txt = "";
                        int min = 10;
                        for (int j = arr.GetLowerBound(1); j <= arr.GetUpperBound(1); j++)
                        {
                            arr[i, j] = rand.Next(0, 9);
                            txt += arr[i, j].ToString() + " ";
                            min = (min > arr[i, j] ? arr[i, j] : min);
                        }
                        Console.WriteLine(txt);
                        mins[i] = min;
                    }

                    //массив минимумов
                    Array.Sort(mins);
                    txt = "";
                    for (int i = mins.Length-1; i >=0 ; i--)
                    {
                        txt += mins[i].ToString() + " ";
                    }

                    v.TaskResult(txt);

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
                v.TaskText("Задание 6.", "Калькулятор.\nС консоли вводится левый операнд, операция, правый операнд.\nВыводится результат операции над операндами.\nРеализовать как минимум 4 операции, обработку ошибок (деление на 0 и др)");
                try
                {
                    v.TaskExtraText("Введите, используя + - / *. например 5 + (-7,8) :");
                    string line = Console.ReadLine().Replace(".", ",");

                    string patt = "([-]*\\d+,*\\d*)\\s*([+,\\*,/,-]*)\\s*[(]*([-]*\\d+,*\\d*)[)]*\\s*$";

                    string aLine = Regex.Match(line, patt).Groups[1].Value;
                    string operand = Regex.Match(line, patt).Groups[2].Value;
                    string bLine = Regex.Match(line, patt).Groups[3].Value;


                    float a = float.Parse(aLine);
                    float b = float.Parse(bLine);

                    string result = "";
                    switch (operand)
                    {
                        case "+":
                            result = (a + b).ToString();
                            break;
                        case "-":
                            result = (a - b).ToString();
                            break;
                        case "*":
                            result = (a * b).ToString();
                            break;
                        case "/":
                            result = (a / b).ToString();
                            break;
                        default:
                            v.TaskWarning("неизвестный операнд");
                            break;
                    }

                    v.TaskResult(result);


                   // break;
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
