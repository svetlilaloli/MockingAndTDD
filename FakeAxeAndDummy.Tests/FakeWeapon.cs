namespace FakeAxeAndDummy.Tests
{
    internal class FakeWeapon : IWeapon
    {
        public bool IsAttackCalled { get; set; } = false;        
        public void Attack(ITarget target)
        {
            IsAttackCalled = true;
        }
    }
}
