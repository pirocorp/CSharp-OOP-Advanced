namespace P05_CreateAttribute
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;

    [SoftUni("Zdravko")]
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var softUniType = typeof(SoftUniAttribute);

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance |
                                          BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                var methodCustomAttributes = method.CustomAttributes;

                if (methodCustomAttributes.Any(n => n.AttributeType == softUniType))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (SoftUniAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}