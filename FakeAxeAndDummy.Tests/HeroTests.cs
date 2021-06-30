using FakeAxeAndDummy;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const string name = "Jack";
    private const int defaultExperience = 0;
    private IWeapon defaultWeapon;
    private Hero hero;
    [SetUp]
    public void SetUp()
    {
        hero = new Hero(name);
        defaultWeapon = new Axe(10, 10);
    }
    [Test]
    public void Constructor_WithValidParameter_ShouldSetFieldsCorrectly()
    {
        var heroName = hero.Name;
        var experience = hero.Experience;
        var weapon = hero.Weapon;
        
        Assert.AreEqual(name, heroName);
        Assert.AreEqual(defaultExperience, experience);
        Assert.IsInstanceOf(typeof(Axe), hero.Weapon);
    }
}