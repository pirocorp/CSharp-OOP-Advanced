namespace _02.Blobs.Entities.Attacks
{
    public class Blobplode : Attack
    {
        public override void Execute(Blob attacker, Blob target)
        {
            attacker.Health -= attacker.Health / 2;
            target.Respond(attacker.Damage * 2);
        }
    }
}