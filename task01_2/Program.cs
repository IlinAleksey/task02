using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_2
{

    class Program
    {
        /// <summary>
        /// Структура для хранения значения и его индекса в массиве
        /// </summary>
        private struct Item : IComparable
        {
            public int value, index;
            public int CompareTo(Object item)
            {
                return CompareTo((Item)item);
            }
            public int CompareTo(Item item)
            {
                return value.CompareTo(item.value);
            }

        }
        /// <summary>
        /// Заполняет двумерный целочисленный массив числами с консоли
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        public static void Fill(int[,] arr)
        {
            int n = arr.GetLength(0), m = arr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; )
                {
                    if (int.TryParse(Console.ReadLine(), out arr[i, j]))
                        j++;
                    else
                        Console.WriteLine("Значение должно быть целым числом! Повторите ввод");
                }
            }
        }
        /// <summary>
        /// Выводит двумерный массив на консоль
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        public static void Show(int[,] arr)
        {
            int n = arr.GetLength(0), m = arr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write("{0}\t", arr[i, j]);
                Console.Write('\n');
            }

        }
        /// <summary>
        /// Находит минимальный элемент в двумерном массиве
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <returns>Минимум в arr</returns>
        public static int FindMin(int[,] arr)
        {
            int min = arr[0, 0];
            foreach (int item in arr)
                if (item < min)
                    min = item;
            return min;
        }
        /// <summary>
        /// Находит максимальный элемент в двумерном массиве
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <returns>Максимум в arr</returns>
        public static int FindMax(int[,] arr)
        {
            int max = arr[0, 0];
            foreach (int item in arr)
                if (item > max)
                    max = item;
            return max;
        }
        /// <summary>
        /// Находит в двумерном массиве минимум и максимум и обменивает их местами
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        public static void SwapMinWithMax(int[,] arr)
        {
            int n = arr.GetLength(0), m = arr.GetLength(1);
            int min = arr[0, 0], max = arr[0, 0], minIndex = 0, maxIndex = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        minIndex = i * m + j;
                    }
                    else if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        maxIndex = i * m + j;
                    }
                }
            }
            arr[maxIndex / m, maxIndex % m] = min;
            arr[minIndex / m, minIndex % m] = max;

        }
        /// <summary>
        /// Создает отсортированный массив структур  вида {элемент, индекс в исходном массиве}
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <returns>Одномерный отсортированный массив</returns>
        private static Item[] CreateSortedArray(int[,] arr)
        {
            int n = arr.GetLength(0), m = arr.GetLength(1);
            Item[] sortedArray = new Item[n * m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int index = i * m + j;
                    sortedArray[index].value = arr[i, j];
                    sortedArray[index].index = index;
                }
            }
            Array.Sort(sortedArray);
            return sortedArray;
        }
        /// <summary>
        /// Находит k экстремумов двумерного массива и меняет их местами
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <param name="k">Количество искомых экстремумов</param>
        public static void SwapKExtremums(int[,] arr, int k)
        {
            if (k >= arr.GetLength(0) * arr.GetLength(1))
                throw new IndexOutOfRangeException();

            Item[] sortedArray = CreateSortedArray(arr);
            int m = arr.GetLength(1);
            int last = m * arr.GetLength(0) - 1;

            for (int i = 0; i < k; i++)
            {
                int minX = sortedArray[i].index / m, minY = sortedArray[i].index % m;
                int maxX = sortedArray[last - i].index / m, maxY = sortedArray[last - i].index % m;
                arr[minX, minY] = sortedArray[last - i].value;
                arr[maxX, maxY] = sortedArray[i].value;
            }

        }
        /// <summary>
        /// Задание №2 - Массивы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = 3, m = 5;
            int[,] numbers = new int[n, m];
            Console.WriteLine("Введите {0} целых чисел (по одному в строке)", n * m);

            Fill(numbers);
            Console.WriteLine("Получившийся массив:");
            Show(numbers);

            Console.WriteLine("Минимум в заданом массиве: {0}", FindMin(numbers));
            Console.WriteLine("Максимум в заданом массиве: {0}", FindMax(numbers));

            SwapMinWithMax(numbers);
            Console.WriteLine("После обмена минимума и максимума:");
            Show(numbers);

            int k = 5;
            try
            {
                SwapKExtremums(numbers, k);
                Console.WriteLine("После обмена {0} экстремумов:", k);
                Show(numbers);
            }
            catch (IndexOutOfRangeException)
            { Console.WriteLine("Количество максимумов {0} превышает количество элементов {1}", k, n * m); }

        }
    }
}
