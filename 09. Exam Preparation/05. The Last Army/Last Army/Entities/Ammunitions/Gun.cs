public class Gun : Ammunition
{
    private const double GUN_WEIGHT = 1.4;

    public Gun()
        : base(nameof(Gun), GUN_WEIGHT)
    {
    }
}