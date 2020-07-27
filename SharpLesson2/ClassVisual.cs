using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLesson2
{
    class ClassVisual
    {
        // настройка для выделения цветом текста задания
        public void TaskText(string taskNumber,string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.WriteLine("\n{0}",taskNumber);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0}",text);
            Console.ResetColor();
        }
        //цвет основного текста
        public void TaskExtraText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan; // устанавливаем цвет
            Console.Write("\n{0}",text);
            Console.ResetColor();
        }
        //цвет ошибки
        public void TaskWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nОшибка!!! {0}",text);
            Console.ResetColor();
        }

        //цвет результата
        public void TaskResult(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\rРезультат: {0}",text);
            Console.ResetColor();
        }

    }
}
