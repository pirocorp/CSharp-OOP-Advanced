namespace P07_InfernoInfinity.Core.Commands
{
    using System.Collections.Generic;
    using Attributes;
    using Interfaces;

    public class Add : Command
    {
        [Inject]
        private readonly IFactory<IGem> gemFactory;
        [Inject]
        private readonly IDictionary<string, IWeapon> weapons;

        public Add(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            var gemType = this.Data[3];
            var socketToPutIn = int.Parse(this.Data[2]);
            var weaponToPutIn = this.Data[1];

            var newGem = this.gemFactory.Create(gemType);
            this.weapons[weaponToPutIn].AddGem(newGem, socketToPutIn);
        }
    }
}