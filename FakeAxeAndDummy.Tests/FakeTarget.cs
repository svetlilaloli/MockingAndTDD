using System;

namespace FakeAxeAndDummy.Tests
{
    internal class FakeTarget : ITarget
    {
        public int GiveExperience()
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }

        public void TakeAttack(int attackPoints)
        {
            throw new NotImplementedException();
        }
    }
}
