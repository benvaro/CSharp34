using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
    class Program
    {
        // Generic-class параметр типу вказуємо після імені класу
        // параметрів може бути декілька
        class Point<T>
        {
            public T X { get; set; }
            public T Y { get; set; }
            public Point(T x, T y)
            {
                X = x;
                Y = y;
            }
            // так як тип наперед незаданий - не можна визначитися із значеннями по замовчуванню
            public Point()
            {
                // тому використовують ключове слово default(T)
                X = default(T);
                Y = default(T);
            }
            // Ми не можемо виконувати арифметичні операції зі змінними узагальненого типу (і операції порівняння)
            //T Distance(Point<T> p2)
            //{
            //    double dist = Math.Sqrt((X - p2.X) + (Y - p2.Y));
            //}
            public override string ToString()
            {
                return $"({X};{Y})";
            }
        }
        static void Main(string[] args)
        {
            // Спеціалізація - створення конкретного екземпляра generic-класу
            Point<int> p = new Point<int>(12, 6);
            Point<double> p2 = new Point<double>();
            Console.WriteLine(p); //
            Console.WriteLine(p2);  //
        }
    }
}
