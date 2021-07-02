namespace FakeAxeAndDummy
{
    public class WeaponFactory
    {
        public static IWeapon CreateWeapon(int attack, int durability)
        {
            return new Axe(attack, durability);
        }
    }
}
