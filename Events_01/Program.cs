using System;
using System.IO;

namespace Events_01
{
    class Program
    {
        public class Account
        {
            public delegate void AccountHandler(string message);

            public event AccountHandler acc; // захищений об'єкт делегата
            int suma;
            string owner;

            public int Suma
            {
                get
                {
                    return suma;
                }
                set
                {
                    suma = value;

                }
            }
            public Account()
            {
                Suma = 1000;
            }
            public void Put(int money)
            {
                Suma += money;
                acc?.Invoke("Рахунок поповнено на " + money);
            }
            public void Take(int money)
            {
                if (money > Suma)
                    acc?.Invoke("Недостатьо грошей на рахунку");
                else
                {
                    Suma -= money;
                    acc?.Invoke("Знято " + money);
                }
            }
            public override string ToString()
            {
                return Suma.ToString();
            }
        }
        static void Main(string[] args)
        {
            Account account = new Account();
            account.acc += Info;
            account.Put(1000);
            Console.WriteLine("Suma = " + account);
            account.Take(3000);
            Console.WriteLine("Suma = " + account);
            Console.WriteLine();
            Account account2 = new Account();
            account2.acc += InfoToFile;
            account2.acc += Info;
            // account2.acc = (string message) => Console.WriteLine("Bye");
            account2.Put(1000);
            Console.WriteLine("Suma = " + account);
            account2.Take(3000);
            Console.WriteLine("Suma = " + account);
        }

        static void Info(string message)
        {
            Console.WriteLine(message);
        }
        static void InfoToFile(string message)
        {
            File.AppendAllText("acc.txt", message + "\n");
        }
    }
}
