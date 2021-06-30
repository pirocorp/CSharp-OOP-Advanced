namespace ValidationAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
