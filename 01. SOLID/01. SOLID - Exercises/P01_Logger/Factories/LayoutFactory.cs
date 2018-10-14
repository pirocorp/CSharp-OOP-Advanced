namespace P01_Logger.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class LayoutFactory
    {
        public ILayout Create(string layoutType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.Contains(layoutType));

            if (!(Activator.CreateInstance(type) is ILayout currentInstance))
            {
                throw new NotSupportedException($"Not supported Layout type: {layoutType}");
            }

            return currentInstance;
        }
    }
}