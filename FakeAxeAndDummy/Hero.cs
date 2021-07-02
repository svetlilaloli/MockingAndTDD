using FakeAxeAndDummy;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FakeAxeAndDummy.Tests")]
public class Hero : IHero
{
    private string name;
    private int experience;
    private IWeapon weapon;

    internal Hero(string name, IWeapon weapon)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = weapon;
    }
    public Hero(string name)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = WeaponFactory.CreateWeapon(10, 10);
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
    }

    public IWeapon Weapon
    {
        get { return this.weapon; }
    }

    public void Attack(ITarget target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
