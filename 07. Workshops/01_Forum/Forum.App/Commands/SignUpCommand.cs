namespace Forum.App.Commands
{
    using System;
    using Contracts;

    public class SignUpCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var username = args[0];
            var password = args[1];

            var success = this.userService.TrySignUpUser(username, password);

            if (!success)
            {
                throw new InvalidOperationException($"Invalid login!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}