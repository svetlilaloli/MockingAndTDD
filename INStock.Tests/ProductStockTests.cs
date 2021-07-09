﻿namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    //using System.Collections.ObjectModel;
    using System.Linq;

    public class ProductStockTests
    {
        private IProductStock stock;
        [SetUp]
        public void SetUp()
        {
            stock = new ProductStock();
        }
        [Test]
        public void Count_ShouldReturnProductsInStockCount()
        {
            var actual = stock.Count;
            Assert.AreEqual(0, actual);
        }
        [Test]
        public void Add_NullProduct_ShouldThrowArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => stock.Add(null));
            StringAssert.Contains("Product cannot be null", ex.Message);
        }
        [Test]
        public void Add_ProductAlreadyInStock_ShouldThrowArgumentException()
        {
            stock.Add(new FakeProduct());
            var ex = Assert.Throws<ArgumentException>(() => stock.Add(new FakeProduct()));
            StringAssert.Contains("This product is already in stock", ex.Message);
        }
        [Test]
        public void Add_ValidProductNotInStock_ShouldAddTheProduct()
        {
            stock.Add(new FakeProduct());
            var expected = 1;
            var actual = stock.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Contains_WhenProductParameterIsNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => stock.Contains(null));
        }
        [Test]
        public void Contains_ValidProductInStock_ShouldReturnTrue()
        {
            var product = new FakeProduct();
            stock.Add(product);
            var actual = stock.Contains(product);
            Assert.IsTrue(actual);
        }
        [Test]
        public void Contains_ValidProductNotInStock_ShouldReturnFalse()
        {
            var product = new FakeProduct();
            var actual = stock.Contains(product);
            Assert.IsFalse(actual);
        }
        [TestCase(-1)]
        [TestCase(333)]
        public void Find_InvalidIndexParameter_ShouldThrowIndexOutOfRangeException(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => stock.Find(index));
        }
        [Test]
        public void Find_ValidIndexParameter_ShouldReturnTheCorrespondingProduct()
        {
            var product = new FakeProduct();
            stock.Add(product);
            var actual = stock.Find(0);
            Assert.IsTrue(product.Equals(actual));
        }
        [Test]
        public void FindByLabel_WhenNotFound_ShouldThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => stock.FindByLabel("some label"));
            StringAssert.Contains("No such product in stock", ex.Message);
        }
        [Test]
        public void FindByLabel_WhenFound_ShouldReturnTheCorrectProduct()
        {
            stock.Add(new FakeProduct());
            var actual = stock.FindByLabel("Chocolate 100g");
            Assert.IsTrue(new FakeProduct().Label == actual.Label);
        }
        [Test]
        public void FindAllInPriceRange_WhenNoProductsInTheRange_ShouldReturnEmptyCollection()
        {
            var expected = new List<IProduct>();
            var actual = stock.FindAllInPriceRange(0, 10);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindAllInPriceRange_WhenProductsAreFound_ShouldReturnCollectionInDescendingOrder()
        {
            var fakeProduct1 = new FakeProduct();
            var fakeProduct2 = new FakeProduct("Watermelon kg", 0.98M);
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);

            var actual = (IEnumerable<Product>)stock.FindAllInPriceRange(0, 2);

            Assert.IsTrue(actual.ElementAt(0).Price > actual.ElementAt(1).Price);
        }
        [Test]
        public void FindAllByPrice_WhenNoMatchingProductsAreFound_ShouldReturnEmptyCollection()
        {
            var expected = new List<IProduct>();
            var actual = stock.FindAllByPrice(10);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindAllByPrice_WhenProductsAreFound_ShouldReturnCollectionWithFoundProducts()
        {
            var fakeProduct1 = new FakeProduct();
            var fakeProduct2 = new FakeProduct("bread", 1.9M);
            var expected = new List<IProduct>(){ fakeProduct1, fakeProduct2 };

            var actual = stock.FindAllByPrice(1.9M);
            Assert.AreEqual(expected, actual);
        }
        public void FindAllInPriceRange_WhenMatchingProductsAreFound_ShouldReturnCollectionOfTheMatchingProducts()
        {
            var fakeProduct1 = new FakeProduct();
            var fakeProduct2 = new FakeProduct("Watermelon kg", 1.9M);
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);

            var actual = stock.FindAllByPrice(1.9M);

            Assert.IsTrue(typeof(ICollection<IProduct>) == actual.GetType());
        }
        [Test]
        public void FindMostExpensiveProduct_WhenTheCollectionIsEmpty_ShouldReturnNull()
        {
            var actual = stock.FindMostExpensiveProduct();
            Assert.IsNull(actual);
        }
        [Test]
        public void FindMostExpensiveProduct_WhenTheCollectionIsNotEmpty_ShouldReturnTheMostExpensiveProduct()
        {
            var fakeProduct1 = new FakeProduct();
            var fakeProduct2 = new FakeProduct("Watermelon kg", 0.98M);
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var actual = stock.FindMostExpensiveProduct();
            Assert.AreEqual(fakeProduct1.Price, actual);
        }
        [Test]
        public void FindAllByQuantity_WhenNoProductsWithTheGivenQuantityAreFound_ShouldReturnEmptyEnumeration()
        {
            var expected = new List<Product>();
            var actual = stock.FindAllByQuantity(10);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindAllByQuantity_WhenProductsWithTheGivenQuantityAreFound_ShouldReturnAllProductsWithTheGivenQuantity()
        {
            var fakeProduct1 = new FakeProduct();
            var fakeProduct2 = new FakeProduct("Watermelon kg", 0.98M);
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var expected = new List<IProduct>() { fakeProduct1, fakeProduct2 };
            var actual = stock.FindAllByQuantity(1);
            Assert.AreEqual(expected, actual);
        }
    }
}
