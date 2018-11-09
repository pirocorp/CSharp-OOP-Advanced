namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Lifecycle.Component;
    using Parser;
    using Parser.Strategies;
    using Providers.TypeProvider;

    public class DependencyContainer : IDependencyContainer
    {
        private const string INITIALIZE_METHOD = "Initialize";

        private readonly IParser parser;
        private readonly ITypeProvider typeProvider;
        private readonly IDictionary<Type, Type> components;
        private readonly IDictionary<Type, object> resolveComponents;

        public DependencyContainer(IParser parser, ITypeProvider typeProvider)
        {
            this.parser = parser;
            this.typeProvider = typeProvider;
            this.components = new Dictionary<Type, Type>();
            this.resolveComponents = new Dictionary<Type, object>();
            this.FillComponents();
        }

        public T Resolve<T>()
        {
            if (!this.components.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException($"Cannot map dependency of type {typeof(T).Name}. It is not annotated with @Component ");
            }

            T result = default(T);

            if (this.components.ContainsKey(typeof(T)))
            {
                var resultType = this.components[typeof(T)];
                result = (T)Activator.CreateInstance(resultType);

                this.ResolveDependencies(result);

                return result;
            }

            result = Activator.CreateInstance<T>();

            this.ResolveDependencies(result);

            return result;
        }

        public void RegisterMapping<TFrom>(object to)
        {
            this.resolveComponents[typeof(TFrom)] = to;
            this.components[typeof(TFrom)] = to.GetType();
        }

        public void ResolveDependencies(object controller)
        {
            var currentDependencies =
                controller.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(x => x.GetCustomAttributes().Any(attr => attr.GetType() == typeof(InjectAttribute)))
                    .ToArray();

            foreach (var currentDependency in currentDependencies)
            {
                var currentDependencySource = currentDependency.FieldType;

                if (!this.components.ContainsKey(currentDependencySource))
                {
                    throw new InvalidOperationException($"Cannot map dependency of type {currentDependencySource.Name}. It is not annotated with InjectAttribute ");
                }

                if (!this.resolveComponents.ContainsKey(currentDependencySource))
                {
                    var currentDependencyTarget = this.components[currentDependencySource];
                    var currentDependencyInstance = Activator.CreateInstance(currentDependencyTarget);
                    currentDependency.SetValue(controller, currentDependencyInstance);
                    this.ResolveDependencies(currentDependencyInstance);

                    this.resolveComponents[currentDependencySource] = currentDependencyInstance;

                    var initMethod = currentDependencyInstance.GetType()
                        .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                        .FirstOrDefault(m => m.Name == INITIALIZE_METHOD && m.GetParameters().Length == 0);

                    initMethod?.Invoke(currentDependencyInstance, new object[0]);
                }
                else
                {
                    var currentDependencyInstance = this.resolveComponents[currentDependencySource];
                    currentDependency.SetValue(controller, currentDependencyInstance);
                }
            }
        }

        public void FillComponents()
        {
            this.parser.Parse(new ComponentParserStrategy(this.typeProvider), this.components);
        }
    }
}