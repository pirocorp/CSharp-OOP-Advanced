namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Contracts;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly Dictionary<string, IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new Dictionary<string, IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models 
            => new ReadOnlyCollection<IBunny>(this.bunnies.Values.ToList());

        public void Add(IBunny model) => this.bunnies.Add(model.Name, model);

        public bool Remove(IBunny model) => this.bunnies.Remove(model.Name);

        public IBunny FindByName(string name) => this.bunnies.ContainsKey(name)
            ? this.bunnies[name]
            : null;
    }
}
