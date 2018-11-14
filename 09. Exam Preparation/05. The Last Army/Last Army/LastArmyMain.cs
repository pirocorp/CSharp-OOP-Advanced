public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        var gameController = new GameController(writer);
        var engine = new Engine(reader, writer, gameController);

        engine.Run();
    }
}