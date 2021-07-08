using System;

namespace INStock
{
    public class Product : IProduct
    {
        private string name;
        private decimal price;
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public string Name 
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Price 
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Product price must be a positive number");
                }
                price = value;
            }
        }
    }
}
