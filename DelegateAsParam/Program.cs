using System;

namespace DelegateAsParam
{
    class Program
    {
        delegate void Transformer(ref int value);
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 6, 2, 8, 3, 12 };
            Print(arr);

            Console.WriteLine("Change Array by Inc");
            ChangeArray(arr, Inc);
            Print(arr);

            Console.WriteLine("Change Array by Mult");
            ChangeArray(arr, new Transformer(Mult));
            Print(arr);

            Console.WriteLine("Change Array by lambda");
            ChangeArray(arr, (ref int x) => x = x * x);
            Print(arr);
        }


        static void ChangeArray(int[] arr, Transformer method)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                method(ref arr[i]);
            }
        }

        static void Inc(ref int value)
        {
            value++;
        }
        static void Mult(ref int value)
        {
            value *= 2;
        }

        static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
