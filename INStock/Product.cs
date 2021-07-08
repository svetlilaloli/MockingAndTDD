using System;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        public Product(string label, decimal price)
        {
            Label = label;
            Price = price;
            Quantity = 0;
        }
        public string Label 
        {
            get
            {
                return label;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be empty");
                }
                label = value;
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
        internal int Quantity { get; private set; }
    }
}
