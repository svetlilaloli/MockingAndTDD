namespace INStock.Tests
{
    using INStock;
    using NUnit.Framework;
    using System;
    public class ProductTests
    {
        [Test]
        public void Constructor_WithValidParameters_ShouldSetFieldsCorrectly()
        {
            var product = new Product("wine", 8.99M);
            Assert.AreEqual("wine", product.Name);
            Assert.AreEqual(8.99M, product.Price);
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