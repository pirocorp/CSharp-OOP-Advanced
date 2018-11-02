namespace Forum.App.Commands
{
    using System;
    using Contracts;

    public class ViewPostMenuCommand : ICommand
    {
        private readonly IMenuFactory menuFactory;

        public ViewPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var postId = int.Parse(args[0]);

            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            var menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName);
            menu.SetId(postId);

            return menu;
        }
    }
}