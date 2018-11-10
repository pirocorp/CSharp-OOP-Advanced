namespace LambdaCore.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Enums;
    using Interfaces.Core.Factories;
    using Interfaces.Models;

    public class FragmentsFactory : IFragmentsFactory
    {
        public IFragment CreateFragment(string[] args)
        {
            //AttachFragment:@type@name@pressureAffection
            var typeString = args[0];
            var name = args[1];
            var pressureAffection = int.Parse(args[2]);

            var assembly = Assembly.GetExecutingAssembly();
            var fragmentType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{typeString}Fragment");

            if (fragmentType == null)
            {
                throw new InvalidOperationException($"{typeString}Fragment not found!");
            }

            if (!typeof(IFragment).IsAssignableFrom(fragmentType))
            {
                throw new InvalidOperationException($"{typeString}Fragment is not a {nameof(IFragment)}!");
            }

            var fragmentEnumType = (FragmentType)Enum.Parse(typeof(FragmentType), typeString);

            var newFragment = (IFragment)Activator.CreateInstance(fragmentType, name, pressureAffection);
            return newFragment;
        }
    }
}