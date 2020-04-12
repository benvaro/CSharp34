using System;
using System.Linq;

namespace Delegates_Std
{
    class Program
    {
        //Action  - delegate void Action<T>(до 16 параметрів)
        // Func   - delegate T_out Func<T_in, T_result>(до 16 парам)
        // Predicate  - delegate bool Predicate()

        static void PrintSquare(int a)
        {
            Console.WriteLine("Square = {0}", a * a);
        }
        static void PrintCube(int a)
        {
            Console.WriteLine("Cube = {0}", a * a * a);
        }
        static void PrintValue<T>(T a)
        {
            Console.WriteLine("Value = {0}", a);
        }

        static int CountDigits(string str)
        {
            return str.Count(c => char.IsDigit(c));
        }

        static int CountVowels(string str)
        {
            return str.Count(c => c == 'o' || c == 'a' || c == 'e' || c == 'i');
        }
        static void Main(string[] args)
        {
            Action<int> action = PrintSquare;
            action(5);
            Console.WriteLine();
            Action<int>[] arrayAction = { PrintCube, PrintSquare, PrintValue<int> };
            foreach (var item in arrayAction)
            {
                item(5);
            }

            Func<string, int> func = CountDigits;
            int result = func("Hello 12 bye 34");
            Console.WriteLine("digits = " + result);

            func += CountVowels;
            Console.WriteLine("Wovels: " + func("Hello world"));

            Func<int, int, double> func2 = (x, y) => (x + y) / 2.0;
            Console.WriteLine("Func2 = " + func2(2, 5)); // 3.5?
        }
    }
}
