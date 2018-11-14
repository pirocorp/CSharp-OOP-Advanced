using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        var id = int.Parse(args[1]);
        var type = args[0];
        var energyOutput = double.Parse(args[2]);

        var clazz = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + "Provider");
        var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        var provider = (IProvider)ctors[0].Invoke(new object[] { id, energyOutput });
        return provider;
    }
}