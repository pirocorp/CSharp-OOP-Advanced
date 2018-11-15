namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Airplanes.Contracts;

	public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
		    var typeOfAirplane = Assembly
		        .GetCallingAssembly()
		        .GetTypes()
		        .FirstOrDefault(t => t.Name == type);

		    if (typeOfAirplane == null)
		    {
		        throw new InvalidOperationException($"{type} not found!");
		    }

		    if (!typeof(IAirplane).IsAssignableFrom(typeOfAirplane))
		    {
		        throw new InvalidOperationException($"{type} is not a {nameof(IAirplane)}!");
		    }

            var instance = (IAirplane)Activator.CreateInstance(typeOfAirplane);

		    return instance;
		}
	}
}