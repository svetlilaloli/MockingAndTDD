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
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
