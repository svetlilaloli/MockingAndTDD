namespace INStock.Tests
{
    using INStock;
    using NUnit.Framework;
    using System;
    public class ProductTests
    {
        [TestCase("wine", 9.99, 6)]
        public void Constructor_WithValidParameters_ShouldSetFieldsCorrectly(string name, decimal price, int quantity)
        {
            var product = new Product(name, price, quantity);
            Assert.AreEqual(name, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }
        [TestCase("", 19.98, 1)]
        [TestCase(" ", 12.76, 1)]
        [TestCase(null, 5.87, 1)]
        [TestCase("Magnum icecream", -5, 1)]
        [TestCase("Bubble gum", 0, 1)]
        [TestCase("Bread", 1.19, -1)]
        public void Constructor_WithInvalidParameter_ShouldThrowArgumentException(string name, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(name, price, quantity));
        }
    }
}