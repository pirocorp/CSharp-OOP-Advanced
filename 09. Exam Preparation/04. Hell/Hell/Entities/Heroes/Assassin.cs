public class Assassin : AbstractHero
{
    private const long ASSASSIN_STRENGTH = 25;
    private const long ASSASSIN_AGILITY = 100;
    private const long ASSASSIN_INTELLIGENCE = 15;
    private const long ASSASSIN_HIT_POINTS = 150;
    private const long ASSASSIN_DAMAGE = 300;

    public Assassin(string name)
        : base(name, ASSASSIN_STRENGTH, ASSASSIN_AGILITY, ASSASSIN_INTELLIGENCE, ASSASSIN_HIT_POINTS, ASSASSIN_DAMAGE)
    {
    }
}