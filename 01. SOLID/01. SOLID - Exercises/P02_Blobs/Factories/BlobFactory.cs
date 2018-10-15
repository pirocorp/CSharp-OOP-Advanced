namespace _02.Blobs.Factories
{
    using Entities;
    using Interfaces;

    public class BlobFactory
    {
        private GenericFactory factory;

        public BlobFactory()
        {
            this.factory = new GenericFactory();
        }

        public Blob Create(string[] parameters)
        {
            //create <name> <health> <damage> <behavior> <attack>
            var name = parameters[1];
            var health = int.Parse(parameters[2]);
            var damage = int.Parse(parameters[3]);

            var behaviorString = parameters[4];
            var behavior = this.factory.Create<IBehavior>(behaviorString);

            var attackString = parameters[5];
            var attack = this.factory.Create<IAttack>(attackString);

            var currentBlob = new Blob(name, health, damage, behavior, attack);
            return currentBlob;
        }
    }
}