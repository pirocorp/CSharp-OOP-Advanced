namespace CS_OOP_Advanced_Exam_Prep_July_2016.Providers.TypeProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Framework.Lifecycle.Component;

    [Component]
    public class TypeProvider : ITypeProvider
    {
        private readonly IList<Assembly> assemblies;
        private readonly List<Type> classes;
        private readonly IDictionary<Type, IEnumerable<Type>> classesByAttribute;
        private readonly IDictionary<Type, IDictionary<Type, IEnumerable<MethodInfo>>> methodsByAttribute;
        private readonly IDictionary<Type, IEnumerable<Type>> subclasses;

        public TypeProvider(params Assembly[] assemblies)
        {
            this.assemblies = new List<Assembly>();
            this.classes = new List<Type>();
            this.classesByAttribute = new Dictionary<Type, IEnumerable<Type>>();
            this.methodsByAttribute = new Dictionary<Type, IDictionary<Type, IEnumerable<MethodInfo>>>();
            this.subclasses = new Dictionary<Type, IEnumerable<Type>>();

            foreach (var assembly in assemblies)
            {
                this.AddAssembly(assembly);
            }
        }

        public void AddAssembly(Assembly assembly)
        {
            this.classes.AddRange(assembly.GetTypes());
            this.assemblies.Add(assembly);
        }

        public IEnumerable<Type> GetClassesByAttribute(Type attributeType)
        {
            if (this.classesByAttribute.ContainsKey(attributeType))
            {
                return this.classesByAttribute[attributeType];
            }

            var result = this.classes
                .Where(c => c.IsDefined(attributeType));

            this.classesByAttribute[attributeType] = result;

            return this.classesByAttribute[attributeType];
        }

        public IEnumerable<MethodInfo> GetMethodsByAttribute(Type fromClass, Type attributeType)
        {
            if (this.methodsByAttribute.ContainsKey(fromClass))
            {
                if (this.methodsByAttribute[fromClass].ContainsKey(attributeType))
                {
                    return this.methodsByAttribute[fromClass][attributeType];
                }
            }
            else
            {
                this.methodsByAttribute[fromClass] = new Dictionary<Type, IEnumerable<MethodInfo>>();
            }

            var result = fromClass.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.IsDefined(attributeType));

            this.methodsByAttribute[fromClass][attributeType] = result;

            return this.methodsByAttribute[fromClass][attributeType];
        }

        public IEnumerable<Type> GetSubClasses(Type superType)
        {
            if (this.subclasses.ContainsKey(superType))
            {
                return this.subclasses[superType];
            }

            var result = this.classes
                .Where(c => superType.IsAssignableFrom(c) && superType != c);

            this.subclasses[superType] = result;

            return this.subclasses[superType];
        }
    }
}