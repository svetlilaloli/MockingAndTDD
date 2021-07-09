﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace INStock
{
    public class ProductStock : IProductStock, IEnumerable<Product>
    {
        private List<IProduct> products;
        public ProductStock()
        {
            products = new List<IProduct>();
        }
        public int Count => products.Count;
        public IProduct this[int index] 
        {
            get
            {
                if (index < 0 || index >= products.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return products[index];
            }
            set
            {
                if (index < 0 || index >= products.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                products[index] = value;
            }
        }
        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }
            var existingProduct = products.Find(x => x.Label.ToLower().Trim() == product.Label.ToLower().Trim());
            if (existingProduct != null)
            {
                throw new ArgumentException("This product is already in stock");
            }
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }
            var existingProduct = products.Find(x => x.Label.ToLower().Trim() == product.Label.ToLower().Trim());
            if (existingProduct != null)
            {
                return true;
            }
            return false;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > products.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return products.FindAll(p => p.Price == price);
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
            var foundProduct = products.Find(p => p.Label.ToLower().Trim() == label.ToLower().Trim());
            if (foundProduct == null)
            {
                throw new ArgumentException("No such product in stock");
            }
            return foundProduct;
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
