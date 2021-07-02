using FakeAxeAndDummy;
using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private const int attack = 50;
    private const int durability = 50;
    private Axe axe;
    [SetUp]
    public void Setup()
    {
        axe = new Axe(attack, durability);
    }
    [Test]
    public void Constructor_WithValidParameters_ShouldSetFieldsCorrectly()
    {
        var actual = false;
        if (axe.AttackPoints == attack && axe.DurabilityPoints == durability)
        {
            actual = true;
        }
        Assert.IsTrue(actual);
    }
    [TestCase(0)]
    [TestCase(-1)]
    public void Attack_WithDurabilityPointsEqualToOrLessThanZero_ShouldThrowInvalidOperationException(int durabilityPoints)
    {
        var axe = new Axe(50, durabilityPoints);
        var fakeDummy = new FakeTarget();
        var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(fakeDummy));
        StringAssert.Contains("Axe is broken", ex.Message);
    }
    [Test]
    public void Attack_DurabilityPointsShouldDecreaseByOneAfterAttack()
    {
        var fakeDummy = new FakeTarget();
        var expected = durability - 1;
        axe.Attack(fakeDummy);
        var actual = axe.DurabilityPoints;
        Assert.AreEqual(expected, actual);
    }
}