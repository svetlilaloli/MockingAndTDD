namespace INStock.Tests
{
    internal class FakeProduct : IProduct
    {
        internal FakeProduct()
        {
            Label = "Chocolate 100g";
            Price = 1.9M;
            Quantity = 1;
        }
        internal FakeProduct(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }
        public string Label { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
