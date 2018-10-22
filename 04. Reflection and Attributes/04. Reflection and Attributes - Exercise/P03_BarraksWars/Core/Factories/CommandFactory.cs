namespace P03_BarraksWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandFactory : ICommandFactory
    {
        public IExecutable CreateCommand(string commandType, string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            //var types = Assembly.GetExecutingAssembly().GetTypes();
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandType.ToLower());

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Command type: {commandType}");
            }

            var instance = Activator.CreateInstance(type, data, repository, unitFactory);

            if (!(instance is IExecutable currentInstance))
            {
                throw new NotSupportedException($"Incorrect Command type: {commandType}");
            }

            return currentInstance;
        }
    }
}