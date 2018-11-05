namespace Forum.App.Commands
{
    using Contracts;

    public class LogOutMenuCommand : ICommand
    {
        private readonly ISession session;
        private readonly IMenuFactory menuFactory;

        public LogOutMenuCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            this.session.Reset();

            var menu = this.menuFactory.CreateMenu("MainMenu");
            return menu;
        }
    }
}