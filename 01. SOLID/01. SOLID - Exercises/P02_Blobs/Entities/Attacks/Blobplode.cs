namespace _02.Blobs.Entities.Attacks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Blobplode : Attack
    {
        public override void Execute(Blob attacker, Blob target)
        {
            attacker.Health -= attacker.Health / 2;
            target.Respond(attacker.Damage * 2);
        }
    }
}