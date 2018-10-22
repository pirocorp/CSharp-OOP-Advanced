namespace P07_InfernoInfinity.Core.Commands
{
    using System.Collections.Generic;
    using Attributes;
    using Interfaces;

    public class Print : Command
    {
        [Inject]
        private readonly IDictionary<string, IWeapon> weapons;
        [Inject]
        private readonly IWriter writer;

        public Print(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            var weaponToPrint = this.Data[1];
            this.writer.WriteLine(this.weapons[weaponToPrint]);
        }
    }
}