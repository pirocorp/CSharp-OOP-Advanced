namespace P06_1984.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class InstitutionsFactory : IInstitutionsFactory
    {
        public IInstitution CreateInstitution(string[] institutionData)
        {
            var institutionType = institutionData[0];

            var id = int.Parse(institutionData[1]);
            var institutionName = institutionData[2];

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == institutionType);

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Unit type: {institutionType}");
            }

            if (!(Activator.CreateInstance(type, id, institutionName) is IInstitution currentInstance))
            {
                throw new NotSupportedException($"Incorrect Unit type: {institutionType}");
            }

            return currentInstance;
        }
    }
}