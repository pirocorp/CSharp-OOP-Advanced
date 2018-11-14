public class NightVision : Ammunition
{
    private const double NIGHT_VISION_WEIGHT = 0.8;

    public NightVision()
        : base(nameof(NightVision), NIGHT_VISION_WEIGHT)
    {
    }
}