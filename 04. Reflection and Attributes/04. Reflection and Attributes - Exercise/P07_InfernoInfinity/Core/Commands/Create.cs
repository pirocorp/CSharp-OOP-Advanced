namespace P07_InfernoInfinity.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Attributes;
    using Interfaces;

    public class Create : Command
    {
        [Inject]
        private IFactory<IWeapon> weaponFactory;
        [Inject]
        private IDictionary<string, IWeapon> weapons;

        public Create(string[] data) 
            : base(data)
        {
        }

        public override void Execute()
        {
            var newWeapon = this.weaponFactory.Create(this.Data.Skip(1).ToArray());
            var newWeaponName = newWeapon.Name;
            this.weapons.Add(newWeaponName, newWeapon);
        }
    }
}