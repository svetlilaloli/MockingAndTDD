namespace INStock.Tests
{
    using INStock;
    using NUnit.Framework;
    using System;
    public class ProductTests
    {
        [TestCase("wine", 9.99)]
        public void Constructor_WithValidParameters_ShouldSetFieldsCorrectly(string name, decimal price)
        {
            var product = new Product(name, price);
            Assert.AreEqual(name, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(0, product.Quantity);
        }
        [TestCase("", 19.98)]
        [TestCase(" ", 12.76)]
        [TestCase(null, 5.87)]
        [TestCase("Magnum icecream", -5)]
        [TestCase("Bubble gum", 0)]
        public void Constructor_WithInvalidParameter_ShouldThrowArgumentException(string name, decimal price)
        {
            Assert.Throws<ArgumentException>(() => new Product(name, price));
        }
    }
}