using FakeAxeAndDummy;

internal class FakeDummy : ITarget
{
    public FakeDummy()
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