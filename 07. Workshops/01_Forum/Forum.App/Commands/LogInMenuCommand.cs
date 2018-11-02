namespace Forum.App.Commands
{
    using Contracts;

    public class LogInMenuCommand : ICommand
    {
        private readonly IMenuFactory menuFactory;

        public LogInMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            var menu = this.menuFactory.CreateMenu(menuName);
            return menu;
        }
    }
}