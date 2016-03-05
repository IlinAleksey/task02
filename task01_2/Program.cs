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
            public int value;
            public int i;
            public int j;
            public Item(int value, int i, int j)
            {
                this.value = value;
                this.i = i;
                this.j = j;
            }
            public int CompareTo(Object item)
            {
                return CompareTo((Item)item);
            }
            public int CompareTo(Item item)
            {
                return value.CompareTo(item.value);
            }
            public override bool Equals(Object item)
            {
                    return value.Equals(((Item)item).value);
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

        }
        /// <summary>
        /// Заполняет двумерный целочисленный массив числами с консоли
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        public static void Fill(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
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
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write("{0}\t", arr[i, j]);
                Console.Write('\n');
            }

        }
        /// <summary>
        /// На место элемента item1 ставит item2, и наоборот
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <param name="item1">Первый элемент</param>
        /// <param name="item2">Второй элемент</param>
        public static void SwapElements(int[,] arr, int item1, int item2)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == item1)
                        arr[i, j] = item2;
                    else if (arr[i, j] == item2)
                        arr[i, j] = item1;
                }
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
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int min = arr[0, 0];
            int max = arr[0, 0];
            int minIndexX = 0;
            int minIndexY = 0;
            int maxIndexX = 0;
            int maxIndexY = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        minIndexX = i;
                        minIndexY = j;
                    }
                    else if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        maxIndexX = i;
                        maxIndexY = j;
                    }
                }
            }
            SwapElements(arr, arr[maxIndexX, maxIndexY], arr[minIndexX, minIndexY]);
        }
        /// <summary>
        /// Создает отсортированный список структур вида {элемент, индекс в исходном массиве} без повторений
        /// </summary>
        /// <param name="arr">Двумерный массив</param>
        /// <returns>Одномерный отсортированный список без повторений</returns>
        private static List<Item> CreateSortedArray(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            List<Item> sortedArray = new List<Item>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int index = i * m + j;
                    Item item = new Item(arr[i, j], i, j);
                    if (sortedArray.IndexOf(item) < 0)
                        sortedArray.Add(item);
                }
            }
            sortedArray.Sort();
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

            List<Item> sortedArray = CreateSortedArray(arr);
            int last = sortedArray.Count-1;
            for (int i = 0; i < k&&i<last; i++)
            {
                int minX = sortedArray[i].i;
                int minY = sortedArray[i].j;
                int maxX = sortedArray[last - i].i;
                int maxY = sortedArray[last - i].j;
                SwapElements(arr, arr[maxX, maxY], arr[minX, minY]);
            }

        }
        /// <summary>
        /// Задание №2 - Массивы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = 3;
            int m = 3;
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
            Console.WriteLine();

            int k = 3;
            try
            {
                SwapKExtremums(numbers, k);
                Console.WriteLine("После обмена {0} экстремумов:", k);
                Show(numbers);
            }
            catch (IndexOutOfRangeException)
            { Console.WriteLine("Количество максимумов {0} превышает количество элементов {1}", k, n * m); }
            Console.WriteLine("Нажмите любую клавишу для завершения");
            Console.ReadKey();

        }
    }
}
