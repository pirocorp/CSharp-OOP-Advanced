namespace P02_BlackBoxInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);

            var constructor = type
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetParameters().Length == 0);

            var instance = (BlackBoxInteger)constructor.Invoke(new object[]{});

            var methods = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .Select(x => new {Key = x.Name, Method = x})
                .ToDictionary(x => x.Key, x => x.Method);

            ProcessCommands(instance, methods);
        }

        private static void ProcessCommands(BlackBoxInteger instance, Dictionary<string, MethodInfo> methods)
        {
            string inputLine;

            var innerValueField = instance.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                .FirstOrDefault();

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split("_");

                var command = tokens[0];
                var argument = int.Parse(tokens[1]);

                var currentMethod = methods[command];
                currentMethod.Invoke(instance, new object[] {argument});

                Console.WriteLine(innerValueField.GetValue(instance));
            }
        }
    }
}
