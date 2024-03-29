﻿namespace Forum.App.Commands
{
    using Contracts;

    public class PreviousPageCommand : ICommand
    {
        private readonly ISession session;

        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var currentMenu = this.session.CurrentMenu;

            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage(false);
            }

            return currentMenu;
        }
    }
}