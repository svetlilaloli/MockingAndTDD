﻿namespace FakeAxeAndDummy
{
    public interface IWeapon
    {
        public bool IsAttackCalled { get; set; }
        public void Attack(ITarget target);
    }
}
