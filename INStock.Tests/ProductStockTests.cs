namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class ProductStockTests
    {
        [Test]
        public void Add_WithNullParameter_ShouldThrowArgumentNullException()
        {
            var stock = new ProductStock();
            Assert.Throws<ArgumentNullException>(() => stock.Add(null));
        }
        [Test]
        public void Add_WithValidParameter_ShouldAddTheProduct()
        {
            var stock = new ProductStock();
            stock.Add(new FakeProduct());
            var expected = 1;
            var actual = stock.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Contains_WithNullParameter_ShouldThrowArgumentNullException()
        {
            var stock = new ProductStock();
            Assert.Throws<ArgumentNullException>(() => stock.Contains(null));
        }
        [Test]
        public void Contains_WithValidParameterAlreadyAddedToTheStock_ShouldReturnTrue()
        {
            var stock = new ProductStock();
            var product = new FakeProduct();
            stock.Add(product);
            var actual = stock.Contains(product);
            Assert.IsTrue(actual);
        }
        [Test]
        public void Contains_WithValidParameterNotAddedToTheStock_ShouldReturnFalse()
        {
            var stock = new ProductStock();
            var product = new FakeProduct();
            var actual = stock.Contains(product);
            Assert.IsFalse(actual);
        }
        [TestCase(-1)]
        [TestCase(333)]
        public void Find_WithInvalidIndexParameter_ShouldThrowIndexOutOfRangeException(int index)
        {
            var stock = new ProductStock();
            Assert.Throws<IndexOutOfRangeException>(() => stock.Find(index));
        }
        [Test]
        public void Find_WithValidIndexParameter_ShouldReturnTheCorrespondingProduct()
        {
            var stock = new ProductStock();
            stock.Add(new FakeProduct());
            var actual = stock.Find(0);
            Assert.IsTrue(new FakeProduct().Equals(actual));
        }
        [Test]
        public void FindByLabel_WhenNotFound_ShouldThrowArgumentException()
        {
            var stock = new ProductStock();
            Assert.Throws<ArgumentException>(() => stock.FindByLabel("some label"));
        }
        [Test]
        public void FindByLabel_WhenFound_ShouldReturnTheProductWithTheGivenLabel()
        {
            var stock = new ProductStock();
            stock.Add(new FakeProduct());
            var actual = stock.FindByLabel("Chocolate 100g");
            Assert.IsTrue(new FakeProduct() == actual);
        }
        [Test]
        public void FindAllInPriceRange_WhenNoProductsInTheRange_ShouldReturnEmptyCollection()
        {
            var stock = new ProductStock();
            var expected = new Collection<IProduct>();
            var actual = stock.FindAllInPriceRange(0, 10);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindAllInPriceRange_WhenProductsAreFound_ShouldReturnCollectionInDescendingOrder()
        {
            var stock = new ProductStock();
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
            var stock = new ProductStock();
            var expected = new Collection<IProduct>();
            var actual = stock.FindAllByPrice(10);
            Assert.AreEqual(expected, actual);
        }
        public void FindAllInPriceRange_WhenMatchingProductsAreFound_ShouldReturnCollectionOfTheMatchingProducts()
        {
            var stock = new ProductStock();
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
            var stock = new ProductStock();
            var actual = stock.FindMostExpensiveProduct();
            Assert.IsNull(actual);
        }
        [Test]
        public void FindMostExpensiveProduct_WhenTheCollectionIsNotEmpty_ShouldReturnTheMostExpensiveProduct()
        {
            var stock = new ProductStock();
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
            var stock = new ProductStock();
            var expected = new Collection<Product>();
            var actual = stock.FindAllByQuantity(10);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindAllByQuantity_WhenProductsWithTheGivenQuantityAreFound_ShouldReturnAllProductsWithTheGivenQuantity()
        {
            var stock = new ProductStock();
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
