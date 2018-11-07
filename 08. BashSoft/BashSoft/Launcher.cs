namespace BashSoft
{
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Repository;
    using IO;
    using Judge;
    using Repository;

    public class Launcher
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IoManager();
            IDatabase repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader =  new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
