namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly Dictionary<string, IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new Dictionary<string, IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => new ReadOnlyCollection<IEgg>(this.eggs.Values.ToList());

        public void Add(IEgg model) => this.eggs.Add(model.Name, model);

        public bool Remove(IEgg model) => this.eggs.Remove(model.Name);

        public IEgg FindByName(string name) => this.eggs.ContainsKey(name)
            ? this.eggs[name]
            : null;
    }
}
