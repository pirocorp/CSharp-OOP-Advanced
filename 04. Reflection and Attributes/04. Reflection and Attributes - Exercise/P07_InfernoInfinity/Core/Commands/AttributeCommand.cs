namespace P07_InfernoInfinity.Core.Commands
{
    using System.Linq;
    using Attributes;
    using Interfaces;
    using Models.Weapons;

    public abstract class AttributeCommand : Command
    {
        [Inject]
        protected readonly IWriter writer;

        protected readonly InfoAttribute attribute;

        protected AttributeCommand(string[] data) 
            : base(data)
        {
            this.attribute = (InfoAttribute)typeof(Weapon).GetCustomAttributes(false).First();
        }
    }
}