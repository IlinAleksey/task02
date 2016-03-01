using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Homework2_1
{
    class Program
    {
        /// <summary>
        /// Задание №1 - Строки
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char[] charArray = { 'H', 'e', '1', '1', 'o', ',', ' ', 's', 'y', 'm', 'b', 'o', '1', 's', ' ', 'w', 'o', 'r', '1', 'd', '!' };

            Console.WriteLine("Создан массив:");
            foreach (var item in charArray)
                Console.Write(item);
            Console.WriteLine('\n');

            StringBuilder myString = new StringBuilder();
            foreach (char symb in charArray)
                myString.Append(symb);
            Console.WriteLine("Создан объект {0}:\n{1}\n", myString.GetType().Name, myString);

            myString.Replace('1', 'l');
            Console.WriteLine("Результат замены 1 на l:\n{0}\n", myString);

            int indexFirst = 7, n = 8;
            myString.Remove(indexFirst, n);
            Console.WriteLine("Результат удаления {0} символов, начиная с позиции {1}:\n{2}\n", n, indexFirst, myString);

            string newPart = "beautiful ";
            myString.Insert(indexFirst, newPart);
            Console.WriteLine("Результат вставки подстроки \"{0}\", начиная с позиции {1}:\n{2}\n", newPart, indexFirst, myString);

        }
    }
}
