public class Knife : Ammunition
{
    private const double KNIFE_WEIGHT = 0.4;

    public Knife()
        : base(nameof(Knife), KNIFE_WEIGHT)
    {
    }
}