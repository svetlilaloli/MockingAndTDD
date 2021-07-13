namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStockTests
    {
        private IProductStock stock;
        private IProduct fakeProduct1;
        private IProduct fakeProduct2;
        [SetUp]
        public void SetUp()
        {
            stock = new ProductStock();
            fakeProduct1 = new FakeProduct();
            fakeProduct2 = new FakeProduct("Watermelon kg", 1.98M, 1);
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
            stock.Add(fakeProduct1);
            var ex = Assert.Throws<ArgumentException>(() => stock.Add(fakeProduct1));
            StringAssert.Contains("This product is already in stock", ex.Message);
        }
        [Test]
        public void Add_ValidProductNotInStock_ShouldAddTheProduct()
        {
            stock.Add(fakeProduct1);
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
            stock.Add(fakeProduct1);
            var actual = stock.Contains(fakeProduct1);
            Assert.IsTrue(actual);
        }
        [Test]
        public void Contains_ValidProductNotInStock_ShouldReturnFalse()
        {
            var actual = stock.Contains(fakeProduct1);
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
            stock.Add(fakeProduct1);
            var actual = stock.Find(0);
            Assert.IsTrue(fakeProduct1.Equals(actual));
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
            stock.Add(fakeProduct1);
            var actual = stock.FindByLabel("Chocolate 100g");
            Assert.IsTrue(fakeProduct1.Label == actual.Label);
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
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var actual = stock.FindAllInPriceRange(0, 2);

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
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var expected = new List<IProduct>(){ fakeProduct1 };

            var actual = stock.FindAllByPrice(1.9M);
            Assert.AreEqual(expected, actual);
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
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var actual = stock.FindMostExpensiveProduct();
            Assert.AreEqual(fakeProduct2.Price, actual.Price);
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
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var expected = new List<IProduct>() { fakeProduct1, fakeProduct2 };
            var actual = stock.FindAllByQuantity(1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetEnumerator_ShouldReturnAllProductsInStock()
        {
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var expectedCount = 2;
            var actualCount = 0;
            foreach (var product in stock)
            {
                actualCount++;
            }
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Indexer_IndexInRange_ShouldReturnTheCorrectProduct()
        {
            stock.Add(fakeProduct1);
            stock.Add(fakeProduct2);
            var expected = fakeProduct2;
            var actual = stock[1];
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Indexer_IndexOutOfRange_ShouldThrowIndexOutOfRangeException()
        {
            var product = new FakeProduct();
            var ex = Assert.Throws<IndexOutOfRangeException>(() => product = (FakeProduct)stock[1]);
            StringAssert.Contains("Index out of range", ex.Message);
        }        
    }
}
