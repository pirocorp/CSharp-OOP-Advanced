namespace P07_CustomList.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class GenericFactory
    {
        public T Create<T>(string typeString, params object[] parameters)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.Contains(typeString)); //Possible problems with similar names!!

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