public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
        IHeroManager manager = new HeroManager();

        var engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}