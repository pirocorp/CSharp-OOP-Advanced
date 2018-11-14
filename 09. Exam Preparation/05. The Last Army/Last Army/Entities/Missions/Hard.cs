public class Hard : Mission
{
    private const string HARD_MISSION_NAME = "Disposal of terrorists";
    private const double HARD_ENDURANCE_REQUIRED = 80;
    private const double HARD_WEAR_LEVEL_DECREASE = 70;

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => HARD_MISSION_NAME;

    public override double EnduranceRequired => HARD_ENDURANCE_REQUIRED;

    public override double WearLevelDecrement => HARD_WEAR_LEVEL_DECREASE;
}