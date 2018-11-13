public class Barbarian : AbstractHero
{
    private const long BARBARIAN_STRENGTH = 90;
    private const long BARBARIAN_AGILITY = 25;
    private const long BARBARIAN_INTELLIGENCE = 10;
    private const long BARBARIAN_HIT_POINTS = 350;
    private const long BARBARIAN_DAMAGE = 150;

    public Barbarian(string name)
        : base(name, BARBARIAN_STRENGTH, BARBARIAN_AGILITY, BARBARIAN_INTELLIGENCE, BARBARIAN_HIT_POINTS, BARBARIAN_DAMAGE)
    {
    }
}