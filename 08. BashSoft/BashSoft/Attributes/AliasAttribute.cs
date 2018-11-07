namespace BashSoft.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private readonly string name;

        public AliasAttribute(string name)
        {
            this.name = name;
        }
        
        public string Name => this.name;

        public override bool Equals(object obj)
        {
            return this.Name.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}