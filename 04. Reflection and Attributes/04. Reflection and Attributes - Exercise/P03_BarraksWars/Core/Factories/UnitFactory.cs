namespace P03_BarraksWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == unitType);

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Unit type: {unitType}");
            }

            if (!(Activator.CreateInstance(type) is IUnit currentInstance))
            {
                throw new NotSupportedException($"Incorrect Unit type: {unitType}");
            }

            return currentInstance;
        }
    }
}