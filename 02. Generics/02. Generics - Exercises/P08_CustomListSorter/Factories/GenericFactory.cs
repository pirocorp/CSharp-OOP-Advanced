namespace P08_CustomListSorter.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class GenericFactory
    {
        public T Create<T>(string typeString, params object[] parameters)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{typeString}Command");

            if (type == null)
            {
                throw new NotSupportedException($"Not supported {typeof(T).Name} type: {typeString}");
            }

            if (!(Activator.CreateInstance(type, parameters) is T currentInstance))
            {
                throw new NotSupportedException($"Not supported {typeof(T).Name} type: {typeString}");
            }

            return currentInstance;
        }
    }
}