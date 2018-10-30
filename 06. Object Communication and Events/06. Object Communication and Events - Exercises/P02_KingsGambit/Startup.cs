namespace P02_KingsGambit
{
    using System.Collections.Generic;
    using Core;
    using Interfaces;

    public class Startup
    {
        public static void Main()
        {
            var military = new Dictionary<string, IUnit>();
            var initializer = new Initializer(military);
            var king = initializer.Initialize();

            var commandInterpreter = new CommandInterpreter(king, military);
            commandInterpreter.Run();
        }
    }
}
