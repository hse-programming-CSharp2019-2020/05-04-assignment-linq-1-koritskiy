﻿using System;
using System.Linq;
using System.Runtime.InteropServices;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr = new int[0];
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Array.ConvertAll(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries),
                    n => int.Parse(n));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            
            try
            {
                checked
                {
                    var filteredCollection =
                        arr.TakeWhile(n => n != 0).Select(n => n * n);

                    // использовать статическую форму вызова метода подсчета среднего
                    var collection = filteredCollection.ToArray();
                    double averageUsingStaticForm = collection.Average();
                    Console.WriteLine($"{averageUsingStaticForm:F3}".Replace('.', ','));

                    // использовать объектную форму вызова метода подсчета среднего
                    double averageUsingInstanceForm = Enumerable.Average(collection);
                    Console.WriteLine($"{averageUsingInstanceForm:F3}".Replace('.', ','));
                }

                // вывести элементы коллекции в одну строку
                Console.WriteLine(arr.TakeWhile(n => n != 0).Select(n => n.ToString())
                    .Aggregate((n, m) => n + " " + m));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
        }
    }
}