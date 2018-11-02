namespace Forum.App.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class MenuFactory : IMenuFactory
    {
        private readonly IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var menuType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == $"{menuName}");

            if (menuType == null)
            {
                throw new InvalidOperationException($"{menuName} not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuName} is not a {nameof(IMenu)}!");
            }

            var ctor = menuType.GetConstructors().First();
            var ctorParams = ctor.GetParameters();

            var args = new object[ctorParams.Length];
            for (var i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            var menu = (IMenu)ctor.Invoke(args);
            return menu;
        }
    }
}