namespace FakeAxeAndDummy.Tests
{
    internal class HeroFactory
    {
        internal Hero CreateHero(string name)
        {
            return new Hero(name);
        }
    }
}
