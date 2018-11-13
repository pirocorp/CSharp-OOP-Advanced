using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly IInputReader reader;
    private readonly IOutputWriter writer;
    private readonly IHeroManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, IHeroManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        var isRunning = true;

        while (isRunning)
        {
            var inputLine = this.reader.ReadLine();
            var arguments = this.ParseInput(inputLine);
            this.writer.WriteLine(this.ProcessInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(List<string> arguments)
    {
        var command = arguments[0];
        arguments.RemoveAt(0);

        var commandType = Type.GetType(command + "Command");
        var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IHeroManager) });
        var cmd = (ICommand)constructor.Invoke(new object[] { arguments, this.heroManager });
        var result = cmd.Execute();

        return result.Trim();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}