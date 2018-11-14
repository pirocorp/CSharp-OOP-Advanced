public class RPG : Ammunition
{
    private const double RPG_WEIGHT = 17.1;

    public RPG()
        : base(nameof(RPG), RPG_WEIGHT)
    {
    }
}