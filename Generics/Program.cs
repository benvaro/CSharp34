using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        // Generics - узагальнення
        // методи, класи, інтерфейси, делегати, структури, колекції
        static void Main(string[] args)
        {
            #region Theory
            ArrayList list = new ArrayList();
            list.Add("One");
            list.Add(2);
            list.Add(3.14);
            list.Add('a');
            object obj = 45;  // boxing
            int a = (int)obj; // unboxing

            List<string> listString = new List<string>(); // 
                                                          // +: 1) безпека типів
                                                          //    2) код більш зрозумілий і простий (не треба приводити до типу)
                                                          //    3) підвищення продуктивності (не виконується boxing/unboxing) 
            #endregion

            int number = 12;
            int number2 = 45;
            Swap<int>(ref number, ref number2);
            Console.WriteLine($"Number = {number}; Number2 = {number2}");

            double nd1 = 34.6;
            double nd2 = 12.67;
            Swap(ref nd1, ref nd2);
            Console.WriteLine($"Number = {nd1}; Number2 = {nd2}");

            int[] arr = { 2, 65, 1, 4, 9, 45 };
            PrintArray(arr);
            //PrintArray<int>(arr);
            Console.WriteLine($"Max = {Max(number, number2)}");

            Film film1 = new Film("Matrix", 5.6);
            Film film2 = new Film("Star wars", 7.8);
            Console.WriteLine($"Max film: {Max(film1, film2)}");
        }
        static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
        static void PrintArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
        // constraints: where T: де тип має реалізувати інтерфейс IComparable
        static T Max<T>(T a, T b) where T : IComparable// class, struct, Interface, new()  
        {
            int result = a.CompareTo(b);
            return (result > 0) ? a : b;
        }

        class Film : IComparable
        {
            public string Title { get; set; }
            public double Rating { get; set; }
            public Film(string title, double rating)
            {
                Title = title;
                Rating = rating;
            }
            public override string ToString()
            {
                return $"{Title} ---> {Rating}";
            }

            public int CompareTo(object obj)
            {
                return this.Rating.CompareTo((obj as Film).Rating);
            }
        }
    }
}
