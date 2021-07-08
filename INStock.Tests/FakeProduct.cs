namespace INStock.Tests
{
    internal class FakeProduct : IProduct
    {
        internal FakeProduct()
        {
            Label = "Chocolate 100g";
            Price = 1.9M;
        }
        internal FakeProduct(string label, decimal price)
        {
            Label = label;
            Price = price;
        }
        public string Label { get; set; }
        public decimal Price { get; set; }
    }
}
