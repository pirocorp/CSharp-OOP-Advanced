namespace CS_OOP_Advanced_Exam_Prep_July_2016.Providers.TypeProvider
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public interface ITypeProvider
    {
        void AddAssembly(Assembly assembly);

        IEnumerable<Type> GetClassesByAttribute(Type attributeType);

        IEnumerable<MethodInfo> GetMethodsByAttribute(Type fromClass, Type attributeType);

        IEnumerable<Type> GetSubClasses(Type superType);
    }
}