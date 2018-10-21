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

            var publicFields = investigatedClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            foreach (var field in publicFields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            var classNonPublicMethods = investigatedClass
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name.StartsWith("get"))
                .ToArray();
            foreach (var getter in classNonPublicMethods)
            {
                result.AppendLine($"{getter.Name} have to be public!");
            }

            var classPublicMethods = investigatedClass
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.Name.StartsWith("set"))
                .ToArray();
            foreach (var setter in classPublicMethods)
            {
                result.AppendLine($"{setter.Name} have to be private!");
            }

            return result.ToString().Trim();
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

        public string CollectGettersAndSetters(string className)
        {
            var result = new StringBuilder();
            var investigatedClass = this.GetClassType(className);

            var methods = investigatedClass.GetMethods(BindingFlags.Instance | BindingFlags.Static | 
                                                       BindingFlags.NonPublic | BindingFlags.Public);

            var getters = methods
                .Where(m => m.Name.Contains("get"))
                .ToArray();
            foreach (var getter in getters)
            {
                result.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            var setters = methods
                .Where(m => m.Name.Contains("set"))
                .ToArray();
            foreach (var setter in setters)
            {
                result.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
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