using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var ammunitionType = this.GetAmmunitionType(ammunitionName);
        return (IAmmunition)Activator.CreateInstance(ammunitionType);
    }

    private Type GetAmmunitionType(string ammunitionName)
    {
        var assemblyTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        return assemblyTypes.FirstOrDefault(t => t.Name == ammunitionName);
    }
}