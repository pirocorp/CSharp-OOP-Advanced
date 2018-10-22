namespace P07_InfernoInfinity
{
    using Core;
    using Core.Factories;
    using Interfaces;
    using IO;

    public class StartUp
    {
        public static void Main()
        {
            IFactory<IWeapon> weaponFactory = new WeaponFactory();
            IFactory<IGem> gemFactory = new GemsFactory();
            IWriter writer = new ConsoleWriter();
            ICommandFactory commandFactory = new CommandFactory(weaponFactory, gemFactory, writer);
            ICommandInterpreter commandInterpreter = new CommandInterpreter(commandFactory);
            IReader reader = new ConsoleReader();
            IEngine engine = new Engine(commandInterpreter, reader, writer);
            engine.Run();
        }
    }
}
