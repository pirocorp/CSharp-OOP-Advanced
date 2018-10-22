namespace P03_BarraksWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
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

            var instance = Activator.CreateInstance(type, new object[]{ data });

            if (!(instance is IExecutable currentInstance))
            {
                throw new NotSupportedException($"Incorrect Command type: {commandType}");
            }

            var injectFields = instance
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(InjectAttribute), false))
                .ToArray();

            foreach (var field in injectFields)
            {
                var fieldType = field.FieldType;

                if (fieldType == typeof(IRepository))
                {
                    field.SetValue(instance, repository);
                    continue;
                }

                if (fieldType == typeof(IUnitFactory))
                {
                    field.SetValue(instance, unitFactory);
                    continue;
                }
            }

            return currentInstance;
        }
    }
}