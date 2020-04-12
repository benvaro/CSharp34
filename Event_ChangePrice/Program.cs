using System;

namespace Event_ChangePrice
{
    class Program
    {
        delegate void PriceChangedHandler();
        class Product
        {
            public event PriceChangedHandler PriceChanged;
            private float price;
            public Product(string name, float p)
            {
                Name = name;
                price = p > 0 ? p : 100;
            }
            public string Name { get; set; }
            public float Price
            {
                get { return price; }
                set
                {
                    if (value < price)
                        PriceChanged();
                    price = value;
                }
            }

        }
        static void Main(string[] args)
        {
            Product p1 = new Product("water", 35);
            p1.PriceChanged += InfoAboutChange;

            p1.Price = 20;
        }

        private static void InfoAboutChange()
        {
            Console.WriteLine("Price was changed!!");
        }
    }
}
