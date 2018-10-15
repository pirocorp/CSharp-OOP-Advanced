namespace P01_Logger.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class AppenderFactory
    {
        public IAppender Create(string appenderType, ILayout layout)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.Contains(appenderType));

            if (!(Activator.CreateInstance(type, new object[]{layout}) is IAppender currentInstance))
            {
                throw new NotSupportedException($"Not supported Layout type: {appenderType}");
            }

            return currentInstance;
        }
    }
}