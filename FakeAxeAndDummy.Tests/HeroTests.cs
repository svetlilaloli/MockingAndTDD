using FakeAxeAndDummy;
using FakeAxeAndDummy.Tests;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const string name = "Jack";
    private const int defaultExperience = 0;
    private IWeapon fakeWeapon;
    private ITarget fakeTarget;
    private Hero hero;
    [SetUp]
    public void SetUp()
    {
        fakeWeapon = new FakeWeapon();
        fakeTarget = new FakeTarget();
        hero = new HeroFactory().CreateHero(name);
    }
    [Test]
    public void Constructor_WithValidParameter_ShouldSetFieldsCorrectly()
    {
        var heroName = hero.Name;
        var experience = hero.Experience;
        var weapon = hero.Weapon;
        
        Assert.AreEqual(name, heroName);
        Assert.AreEqual(defaultExperience, experience);
        Assert.IsInstanceOf(typeof(Axe), weapon);
    }
    [Test]
    public void Attack_WithValidTargetParameter_ShouldCallWeaponsAttackMethodOnce()
    {
        hero = new Hero(name, fakeWeapon);
        
        hero.Attack(fakeTarget);
        
        Assert.IsTrue(fakeWeapon.IsAttackCalled);
    }
    [Test]
    public void Attack_TargetIsDeadAfterAttack_HeroShouldGainExperience()
    {
        hero = new Hero(name, fakeWeapon);
        
        hero.Attack(fakeTarget);
        var expected = defaultExperience + 10;
        var actual = hero.Experience;
        
        Assert.AreEqual(expected, actual);
    }
}