using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private const int health = 50;
    private const int experience = 50;
    private const int attackPoints = 8;
    private Dummy dummy;
    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
    }
    [Test]
    public void Constructor_WithValidParameters_ShouldSetFieldsCorrectly()
    {
        var actual = dummy.Health;
        Assert.AreEqual(health, actual);
    }
    [TestCase(0)]
    [TestCase(-1)]
    public void IsDead_DummyWithHealthEqualToOrLessThanZero_ShouldReturnTrue(int health)
    {
        dummy = new Dummy(health, experience);
        Assert.IsTrue(dummy.IsDead());
    }
    [Test]
    public void IsDead_DummyWithHealthGreaterThanZero_ShouldReturnFalse()
    {
        Assert.IsFalse(dummy.IsDead());
    }
    [Test]
    public void GiveExperience_NotDeadDummy_ShouldThrowInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        StringAssert.Contains("Target is not dead", ex.Message);
    }
    [Test]
    public void GiveExperience_DeadDummy_ShouldReturnDummyExperience()
    {
        dummy = new Dummy(0, experience);
        var expected = experience;
        var actual = dummy.GiveExperience();
        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void TakeAttack_DeadDummy_ShouldThrowInvalidOperationException()
    {
        dummy = new Dummy(0, experience);
        var ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
        StringAssert.Contains("Dummy is dead", ex.Message);
    }
    [Test]
    public void TakeAttack_NotDeadDummy_ShouldDecreaseItsHealthByAttackPoints()
    {
        var expected = health - attackPoints;
        dummy.TakeAttack(attackPoints);
        var actual = dummy.Health;
        Assert.AreEqual(expected, actual);
    }
}
