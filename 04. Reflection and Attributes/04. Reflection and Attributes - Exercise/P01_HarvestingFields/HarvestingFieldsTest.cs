 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "HARVEST")
            {
                switch (inputLine)
                {
                    case "private":
                        PrintPrivateFields();
                        break;
                    case "protected":
                        PrintProtectedFields();
                        break;
                    case "public":
                        PrintPublicFields();
                        break;
                    case "all":
                        PrintAllFields();
                        break;
                }
            }
        }

        private static void PrintAllFields()
        {
            var publicFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .ToArray();

            PrintFields(publicFields);
        }

        private static void PrintPublicFields()
        {
            var publicFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
                .ToArray();

            PrintFields(publicFields);
        }

        private static void PrintProtectedFields()
        {
            var protectedFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
                .Where(f => f.IsFamily)
                .ToArray();

            PrintFields(protectedFields);
        }

        private static void PrintPrivateFields()
        {
            var privateFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            PrintFields(privateFields);
        }

        private static void PrintFields(FieldInfo[] protectedFields)
        {
            foreach (var field in protectedFields)
            {
                var accessModifier = GetAccessModifier(field);
                Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }
        }

        private static string GetAccessModifier(FieldInfo field)
        {
            var accessModifier = string.Empty;

            if (field.IsFamily)
            {
                accessModifier = "protected";
            }

            if (field.IsPrivate)
            {
                accessModifier = "private";
            }

            if (field.IsPublic)
            {
                accessModifier = "public";
            }

            return accessModifier;
        }
    }
}
