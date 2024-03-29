﻿namespace _02.Blobs.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class GenericFactory
    {
        public T Create<T>(string typeString)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.Contains(typeString));

            if (type == null)
            {
                throw new NotSupportedException($"Not supported {typeof(T).Name} type: {typeString}");
            }

            if (!(Activator.CreateInstance(type) is T currentInstance))
            {
                throw new NotSupportedException($"Not supported {typeof(T).Name} type: {typeString}");
            }

            return currentInstance;
        }
    }
}