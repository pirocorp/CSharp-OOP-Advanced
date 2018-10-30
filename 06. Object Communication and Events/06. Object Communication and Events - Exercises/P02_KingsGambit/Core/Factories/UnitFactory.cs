namespace P02_KingsGambit.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using IO;

    public class UnitFactory : IUnitFactory
    {
        private readonly IWriter writer;

        public UnitFactory()
            :this(new ConsoleWriter())
        {
            
        }

        public UnitFactory(IWriter writer)
        {
            this.writer = writer;
        }

        public IUnit CreateUnit(string unitType, string name)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == unitType);

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Unit type: {unitType}");
            }

            if (!(Activator.CreateInstance(type, this.writer, name) is IUnit currentInstance))
            {
                throw new NotSupportedException($"Incorrect Unit type: {unitType}");
            }

            return currentInstance;
        }
    }
}