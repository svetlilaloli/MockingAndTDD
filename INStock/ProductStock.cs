using System;
using System.Collections.Generic;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private int quantity;
        private IProduct[] products;
        public int Count => throw new NotImplementedException();
        public IProduct this[int index] 
        {
            get
            {
                if (index < 0 || index >= products.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return products[index];
            }
            set
            {
                if (index < 0 || index >= products.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                products[index] = value;
            }
        }
        public void Add(IProduct product)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IProduct product)
        {
            throw new NotImplementedException();
        }

        public IProduct Find(int index)
        {
            throw new NotImplementedException();
        }

        public ICollection<IProduct> FindAllByPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal start, decimal end)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }
    }
}
