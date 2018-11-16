namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
		    var instrumentType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

		    if (instrumentType == null)
		    {
		        throw new InvalidOperationException("Invalid set type");
		    }

		    if (!typeof(IInstrument).IsAssignableFrom(instrumentType))
		    {
		        throw new IndexOutOfRangeException($"{instrumentType} is not {nameof(IInstrument)} type.");
		    }

		    var setInstance = (IInstrument)Activator.CreateInstance(instrumentType);
		    return setInstance;
        }
	}
}