namespace CommandPattern
{
    public static class StartUp
    {
        public static void Main(string[] args)
        {
            var command = new CommandInterpreter();
            var engine = new Engine(command);
            engine.Run();
        }
    }
}
