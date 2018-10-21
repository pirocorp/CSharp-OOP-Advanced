namespace P01_Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] nameOfFields)
        {
            var result = new StringBuilder();

            var investigatedClass = this.GetClassType(className);
            var instanceOfInvestigatedClass = Activator.CreateInstance(investigatedClass);

            result.AppendLine($"Class under investigation: {className}");

            var fields = investigatedClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                                                     | BindingFlags.Static | BindingFlags.Public);

            foreach (var fieldInfo in fields)
            {
                var fieldName = fieldInfo.Name;

                if (nameOfFields.Contains(fieldName))
                {
                    var fieldValue = fieldInfo.GetValue(instanceOfInvestigatedClass);
                    result.AppendLine($"{fieldName} = {fieldValue}");
                }
            }

            return result.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var result = new StringBuilder();

            var investigatedClass = this.GetClassType(className);

            var publicFields = investigatedClass.GetFields();
            foreach (var field in publicFields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            var properties = investigatedClass.GetProperties(BindingFlags.NonPublic | BindingFlags.Public |
                                                                  BindingFlags.Instance | BindingFlags.Static);

            var nonPublicGetters = properties
                .Where(p => !p.GetMethod.IsPublic)
                .ToArray();
            foreach (var getter in nonPublicGetters)
            {
                result.AppendLine($"get_{getter.Name} have to be public!");
            }

            var publicSetters = properties
                .Where(p => p.SetMethod.IsPublic)
                .ToArray();
            foreach (var setter in publicSetters)
            {
                result.AppendLine($"set_{setter.Name} have to be private!");
            }

            return result.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            var result = new StringBuilder();
            var investigatedClass = this.GetClassType(className);

            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {investigatedClass.BaseType.Name}");

            var allPrivateMethods = investigatedClass
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .ToArray();
            foreach (var method in allPrivateMethods)
            {
                result.AppendLine($"{method.Name}");
            }

            return result.ToString();
        }

        private Type GetClassType(string classToInvestigate)
        {
            var namespaceAsString = this.GetType().Namespace;
            var investigatedClass = Type.GetType($"{namespaceAsString}.{classToInvestigate}");

            return investigatedClass;
        }
    }
}