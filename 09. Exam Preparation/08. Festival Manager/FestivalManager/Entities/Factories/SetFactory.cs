namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
		    var setType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

		    if (setType == null)
		    {
		        throw new InvalidOperationException("Invalid set type");
		    }

		    if (!typeof(ISet).IsAssignableFrom(setType))
		    {
                throw new IndexOutOfRangeException($"{setType} is not {nameof(ISet)} type.");
		    }

		    var setInstance = (ISet)Activator.CreateInstance(setType, name);
		    return setInstance;
		}
	}
}