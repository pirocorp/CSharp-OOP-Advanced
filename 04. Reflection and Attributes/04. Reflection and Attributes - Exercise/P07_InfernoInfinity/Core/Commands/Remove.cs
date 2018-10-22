namespace P07_InfernoInfinity.Core.Commands
{
    using System.Collections.Generic;
    using Attributes;
    using Interfaces;

    public class Remove : Command
    {
        [Inject]
        private readonly IDictionary<string, IWeapon> weapons;

        public Remove(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            var weaponToRemoveFrom = this.Data[1];
            var socketToRemoveFrom = int.Parse(this.Data[2]);

            this.weapons[weaponToRemoveFrom].RemoveGem(socketToRemoveFrom);
        }
    }
}