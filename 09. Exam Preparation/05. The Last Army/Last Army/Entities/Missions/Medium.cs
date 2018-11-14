public class Medium : Mission
{
    private const string MEDIUM_MISSION_NAME = "Capturing dangerous criminals";
    private const double MEDIUM_ENDURANCE_REQUIRED = 50;
    private const double MEDIUM_WEAR_LEVEL_DECREASE = 50;

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => MEDIUM_MISSION_NAME;

    public override double EnduranceRequired => MEDIUM_ENDURANCE_REQUIRED;

    public override double WearLevelDecrement => MEDIUM_WEAR_LEVEL_DECREASE;
}