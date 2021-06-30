namespace FakeAxeAndDummy
{
    public class WeaponFactory
    {
        public IWeapon CreateWeapon(int attack, int durability)
        {
            return new Axe(attack, durability);
        }
    }
}
