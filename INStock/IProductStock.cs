using System.Collections.Generic;

namespace INStock
{
    public interface IProductStock
    {
        public int Count { get; }
        public void Add(IProduct product);
        public bool Contains(IProduct product);
        public IProduct Find(int index);
        public IProduct FindByLabel(string label);
        public IEnumerable<IProduct> FindAllInPriceRange(decimal start, decimal end);
        public ICollection<IProduct> FindAllByPrice(decimal price);
        public IProduct FindMostExpensiveProduct();
        public IEnumerable<IProduct> FindAllByQuantity(int quantity);
    }
}
