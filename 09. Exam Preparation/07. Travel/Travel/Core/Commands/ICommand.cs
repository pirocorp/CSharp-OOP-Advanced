namespace Travel.Core.Commands
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Execute(IList<string> args);
    }
}