namespace P06_1984.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class EntityFactory : IEntityFactory
    {
        public IEntity CreateEntity(params string[] entityData)
        {
            var entityType = entityData[0];

            var entityId = int.Parse(entityData[1]);
            var entityName = entityData[2];

            var restParams = entityData.Skip(3).Select(int.Parse).ToArray();

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == entityType);

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Unit type: {entityType}");
            }

            if (!(Activator.CreateInstance(type, entityId, entityName, restParams) is IEntity currentInstance))
            {
                throw new NotSupportedException($"Incorrect Unit type: {entityType}");
            }

            return currentInstance;
        }
    }
}