﻿namespace FakeAxeAndDummy
{
    public interface ITarget
    {
        public void TakeAttack(int attackPoints);
        public int GiveExperience();
        public bool IsDead();
    }
}
