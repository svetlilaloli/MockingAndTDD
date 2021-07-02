using FakeAxeAndDummy;

internal class FakeTarget : ITarget
{
    public FakeTarget()
    {
    }

    public int GiveExperience()
    {
        return 10;
    }

    public bool IsDead()
    {
        return true;
    }

    public void TakeAttack(int attackPoints)
    {
        
    }
}