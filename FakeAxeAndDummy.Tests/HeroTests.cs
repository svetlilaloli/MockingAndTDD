using FakeAxeAndDummy;
using FakeAxeAndDummy.Tests;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const string name = "Jack";
    private const int defaultExperience = 0;
    private Hero hero;

    [Test]
    public void Constructor_WithValidParameter_ShouldSetFieldsCorrectly()
    {
        hero = new HeroFactory().CreateHero(name);
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
        var mockedWeapon = new Mock<IWeapon>();
        var mockedTarget = new Mock<ITarget>();
        hero = new Hero(name, mockedWeapon.Object);
        
        hero.Attack(mockedTarget.Object);
        
        mockedWeapon.Verify(x => x.Attack(It.IsAny<ITarget>()), Times.Once);
    }
    [Test]
    public void Attack_TargetIsDeadAfterAttack_HeroShouldGainExperience()
    {
        var mockedWeapon = new Mock<IWeapon>().Object;
        var mockedTarget = new Mock<ITarget>();
        mockedTarget.Setup(x => x.IsDead()).Returns(true);
        mockedTarget.Setup(x => x.GiveExperience()).Returns(10);
        hero = new Hero(name, mockedWeapon);
        
        hero.Attack(mockedTarget.Object);
        
        var expected = defaultExperience + 10;
        var actual = hero.Experience;
        Assert.AreEqual(expected, actual);
    }
}