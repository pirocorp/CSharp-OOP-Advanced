﻿namespace Forum.App.Commands
{
    using Contracts;

    public class NextPageCommand : ICommand
    {
        private readonly ISession session;

        public NextPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var currentMenu = this.session.CurrentMenu;

            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage();
            }

            return currentMenu;
        }
    }
}