public class Wizard : AbstractHero
{
    private const long WIZARD_STRENGTH = 25;
    private const long WIZARD_AGILITY = 25;
    private const long WIZARD_INTELLIGENCE = 100;
    private const long WIZARD_HIT_POINTS = 100;
    private const long WIZARD_DAMAGE = 250;

    public Wizard(string name)
        : base(name, WIZARD_STRENGTH, WIZARD_AGILITY, WIZARD_INTELLIGENCE, WIZARD_HIT_POINTS, WIZARD_DAMAGE)
    {
    }
}