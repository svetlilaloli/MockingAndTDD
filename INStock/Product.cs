using System;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
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
        public int Quantity 
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Product quantity cannot be a negative number");
                }
                quantity = value;
            }
        }
    }
}
