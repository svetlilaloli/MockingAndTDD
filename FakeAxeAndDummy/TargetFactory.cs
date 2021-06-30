namespace FakeAxeAndDummy
{
    public class TargetFactory
    {
        public ITarget CreateTarget(int health, int experience)
        {
            return new Dummy(health, experience);
        }
    }
}
