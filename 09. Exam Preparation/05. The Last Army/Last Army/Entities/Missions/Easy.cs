public class Easy : Mission
{
    private const string EASY_MISSION_NAME = "Suppression of civil rebellion";
    private const double EASY_ENDURANCE_REQUIRED = 20;
    private const double EASY_WEAR_LEVEL_DECREASE = 30;

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => EASY_MISSION_NAME;

    public override double EnduranceRequired => EASY_ENDURANCE_REQUIRED;

    public override double WearLevelDecrement => EASY_WEAR_LEVEL_DECREASE;
}