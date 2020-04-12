using System;

namespace Delegate02
{
    class Program
    {
        delegate void MyDelegate(string str);
        static void Hello(string s)
        {
            Console.WriteLine("Hello {0}", s);
        }
        static void Bye(string s)
        {
            Console.WriteLine("Bye {0}", s);
        }
        static void GoodEvening(string s)
        {
            Console.WriteLine("Good evening {0}", s);
        }

        delegate int SimpleDelegate(int s);
        static int Foo(int s)
        {
            if (s == 0)
                throw new Exception("Invalid arg");
            return 1;
        }
        static int Bar(int s)
        {
            return 2;
        }
        static void Main(string[] args)
        {
            #region TestDelegate
            //MyDelegate a, b, c, d;
            //a = new MyDelegate(Hello);
            //b = new MyDelegate(Bye);

            //c = a + b;

            //d = c - a;
            //Console.WriteLine("Invoke a: ");
            //a("A");
            //Console.WriteLine("Invoke b: ");
            //b("B");
            //Console.WriteLine("Invoke c: ");
            //c("C");
            //Console.WriteLine("Invoke d: ");
            //d("D"); 
            #endregion

            // багатоадресність делегата
            #region Test multicast
            //MyDelegate test = Hello;
            //test += Bye;
            //test("test");  // 
            //Console.WriteLine();

            //test -= Hello;
            //test -= Hello;
            //test?.Invoke("After remove");
            //Console.WriteLine();
            //test += Hello;
            //test += GoodEvening;
            //test += Hello;
            //test += Bye;
            //test -= Hello;
            //test("Test");   // ? hello goodevening  bye 
            #endregion

            #region Test multicast with return value
            SimpleDelegate del = Foo;
            del += Bar;
            del += Foo;
            Console.WriteLine(del(4));
            Console.WriteLine();
            foreach (Delegate item in del.GetInvocationList())// масив делегатів
            {
                Console.WriteLine(item.DynamicInvoke(4));
            }
            #endregion
        }
    }
}
