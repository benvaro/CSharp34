using System;
using System.Collections.Generic;

namespace GenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<List<string>> list = new List<List<string>>();
            List<string> list = new List<string>();
            string[] words = { "car", "train", "bus", "plane" };
            list.AddRange(words);
            foreach (var item in words)
            {
                list.Add(item);
            }

            string[] array = list.ToArray();
           // list.Clear(); // Очистити весь список
            Console.WriteLine("Capacity: " + list.Capacity);
            if(list.Contains("train"))
            {
                list.Remove("train");
            }
            Print(list);
            string el = list.Find(x=>x.StartsWith("b"));
            Console.WriteLine("Find: " + el);
        }

        //private static void Print(ICollection<string> list)
        private static void Print(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
