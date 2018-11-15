namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
		    var typeOfItem = Assembly
		        .GetCallingAssembly()
		        .GetTypes()
		        .FirstOrDefault(t => t.Name == type);

		    if (typeOfItem == null)
		    {
		        throw new InvalidOperationException($"{type} not found!");
		    }

		    if (!typeof(IItem).IsAssignableFrom(typeOfItem))
		    {
		        throw new InvalidOperationException($"{type} is not a {nameof(IItem)}!");
		    }

		    var instance = (IItem)Activator.CreateInstance(typeOfItem);

		    return instance;
        }
	}
}
