namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Parser.Strategies
{
    using System;
    using System.Collections.Generic;
    using Lifecycle.Component;
    using Providers.TypeProvider;

    public class ComponentParserStrategy : IAttributeParserStrategy<Type, Type>
    {
        private readonly ITypeProvider typeProvider;

        public ComponentParserStrategy(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Parse(IDictionary<Type, Type> result)
        {
            foreach (var componentType in this.typeProvider.GetClassesByAttribute(typeof(ComponentAttribute)))
            {
                foreach (var parent in componentType.GetInterfaces())
                {
                    result.Add(parent, componentType);
                }
            }
        }
    }
}