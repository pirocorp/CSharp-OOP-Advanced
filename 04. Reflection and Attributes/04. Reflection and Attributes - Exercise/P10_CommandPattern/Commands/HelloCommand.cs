namespace P10_CommandPattern.Commands
{
    using CommandPattern.Core.Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args) => $"Hello, {(args.Length > 0 ? args[0] : string.Empty)}";
    }
}
