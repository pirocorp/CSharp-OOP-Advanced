namespace LambdaCore.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces.Core.Factories;
    using Interfaces.Models;

    public class CoreFactory : ICoreFactory
    {
        public ICore CreateCore(char coreName, string[] args)
        {
            //CreateCore:@System@2000
            var type = args[0];
            var durability = int.Parse(args[1]);

            var assembly = Assembly.GetExecutingAssembly();

            var coreType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == $"{type}Core");

            if (coreType == null)
            {
                throw new InvalidOperationException($"{type}Core not found!");
            }

            if (!typeof(ICore).IsAssignableFrom(coreType))
            {
                throw new InvalidOperationException($"{type}Core is not a {nameof(ICore)}!");
            }

            var newCore = (ICore)Activator.CreateInstance(coreType, new string(coreName, 1), durability);
            return newCore;
        }
    }
}