namespace Forum.App.Commands
{
    using Contracts;

    public class AddReplyCommand : ICommand
    {
        private readonly IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length - "Command".Length) + "Menu";

            var menu = this.menuFactory.CreateMenu(menuName);

            var postId = int.Parse(args[0]);

            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}