using System.Linq;

public class Engine
{
    private readonly ICommandInterpreter commandInterpreter;
    private readonly IReader reader;
    private readonly IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var inputTokens = this.reader.ReadLine().Split().ToList();

            var result = this.commandInterpreter.ProcessCommand(inputTokens);
            this.writer.WriteLine(result);

            if (inputTokens[0] == "Shutdown")
            {
                break;
            }
        }
    }
}