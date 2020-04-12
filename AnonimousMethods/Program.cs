using System;
using System.Linq;

namespace AnonimousMethods
{
    class Program
    {
        delegate int CalcDeleg(int a);
        delegate double CalcAverageDeleg(params int[] a);
        delegate int Transformer(ref int a);
        static void Main(string[] args)
        {
            CalcDeleg sqr = delegate (int x)
                            {
                                return x * x;
                            };
            Console.WriteLine("sqr(10) = " + sqr(10));

            CalcDeleg cube = delegate (int x)
                            {
                                return sqr(x) * x;
                            };
            Console.WriteLine("Cube(5) = " + cube(5));
            int number = 100;
            CalcDeleg test = delegate (int x)
            {
                return number + x;
            };
            Console.WriteLine("Test(5) = " + test(5)); // ?  105
            number++; // 101
            CalcDeleg deleg = delegate { return number; }; // якщо параметр не використовується - то можна упустити
            Console.WriteLine(deleg(-7878));

            CalcAverageDeleg avg = delegate (int[] a)
            {

                double avgTemp = a.Average();
                return avgTemp;
            };
            Console.WriteLine("Average = " + avg(1, 2, 3, 4, 5));

            Transformer t = (ref int a) => a--;
            Console.WriteLine("transformer -- " + t(ref number) + "  --> " + number);
        }
    }
}
