namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Constants;
    using Items;

    /// <summary>
    /// TODO: Use dictionary for optimization.
    /// </summary>
    public abstract class Bag : IBag
    {
        private readonly IList<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;

            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => new ReadOnlyCollection<Item>(this.items);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var resultItem = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (resultItem is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(resultItem);
            return resultItem;
        }
    }
}
