namespace P07_InfernoInfinity.Core.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Interfaces;

    public class CommandFactory : ICommandFactory
    {
        private readonly IFactory<IWeapon> weaponFactory;
        private readonly IFactory<IGem> gemFactory;
        private readonly IWriter writer;

        public CommandFactory(IFactory<IWeapon> weaponFactory, IFactory<IGem> gemFactory, IWriter writer)
        {
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
            this.writer = writer;
        }

        public IExecutable CreateCommand(string commandType, string[] data, IDictionary<string, IWeapon> weapons)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandType.ToLower());

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Command type: {commandType}");
            }

            var instance = Activator.CreateInstance(type, new object[] { data });

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

                if (fieldType == typeof(IFactory<IWeapon>))
                {
                    field.SetValue(instance, weaponFactory);
                    continue;
                }

                if (fieldType == typeof(IFactory<IGem>))
                {
                    field.SetValue(instance, gemFactory);
                    continue;
                }

                if (fieldType == typeof(IDictionary<string, IWeapon>))
                {
                    field.SetValue(instance, weapons);
                    continue;
                }

                if (fieldType == typeof(IWriter))
                {
                    field.SetValue(instance, writer);
                    continue;
                }
            }

            return currentInstance;
        }
    }
}