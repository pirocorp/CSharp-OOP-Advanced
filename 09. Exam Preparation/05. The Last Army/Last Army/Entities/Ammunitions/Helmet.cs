public class Helmet : Ammunition
{
    private const double HELMET_WEIGHT = 2.3;

    public Helmet()
        : base(nameof(Helmet), HELMET_WEIGHT)
    {
    }
}