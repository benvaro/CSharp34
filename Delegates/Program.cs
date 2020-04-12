using System;

namespace Delegates
{
    class Program
    {
        delegate double DelCalc(double first, double second); // тип делегата, такого типу делегати можуть посилатись на
                                                              // метод з відповідною сигнатурою
        class Calc
        {
            double number;
            public Calc(double num)
            {
                number = num;
            }
            public static double Add(double a, double b)
            {
                return a + b;
            }
            public static double Sub(double a, double b)
            {
                return a - b;
            }
            public double Mult(double a, double b)
            {
                return number = a * b;
            }
            public double Div(double a, double b)
            {
                return number = a / b;
            }
        }
        static void Main(string[] args)
        {
            DelCalc d1 = new DelCalc(Calc.Add); // створила екземпляр делегата, який посилається
                                                // на статичний метод класу Calc
            Console.WriteLine("d1 = Calc.Add; d1(23,1) = {0}", d1(23, 1));
            Console.WriteLine($"Method name: {d1.Method.Name} \n Target name: {d1.Target}"); // інформація про об'єкт
                                                                                             // Target = null - бо метод статичний
            d1 = Calc.Sub;
            Console.WriteLine("d1 = Calc.Sub; d1(23,1) = {0}", d1.Invoke(23, 1));
            Console.WriteLine($"Method name: {d1.Method.Name} \n Target name: {d1.Target}"); // інформація про об'єкт

            Calc calc = new Calc(10);
            d1 = calc.Mult;
            Console.WriteLine("d1 = Calc.Mult; d1(3,4) = {0}", d1(3, 4));
            Console.WriteLine($"Method name: {d1.Method.Name} \n Target name: {d1.Target}"); // інформація про об'єкт

            DelCalc d2 = new DelCalc(Calc.Add);
            if (d2 != null)
                Console.WriteLine(d2(3, 5));

            Console.WriteLine(d2?.Invoke(3, 5));

        }
    }
}
