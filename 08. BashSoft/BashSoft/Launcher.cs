namespace BashSoft
{
    using Contracts.IO;
    using IO;
    using Judge;
    using Repository;

    public class Launcher
    {
        public static void Main()
        {
            var tester = new Tester();
            IDirectoryManager ioManager = new IoManager();
            var repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader =  new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
