using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassTasks tasks = new ClassTasks();
            bool loop = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.Write("\nВведите номер задачи (с 1 по 6, 0 - все задачи, exit - для завершения) ");
                Console.ResetColor();
                string line = Console.ReadLine();

                switch (line)
                {
                    case "1":
                        tasks.Task1();
                        break;
                    case "2":
                        tasks.Task2();
                        break;
                    case "3":
                        tasks.Task3();
                        break;
                    case "4":
                        tasks.Task4();
                        break;
                    case "5":
                        tasks.Task5();
                        break;
                    case "6":
                        tasks.Task6();
                        break;
                    case "0":
                        tasks.Task1();
                        tasks.Task2();
                        tasks.Task3();
                        tasks.Task4();
                        tasks.Task5();
                        tasks.Task6();
                        break;
                    case "exit":
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
            while (loop);
        }
    }
}
