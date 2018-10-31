namespace P06_1984.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using EventArgs;
    using Interfaces;

    public class Institution : IInstitution
    {
        private int numberOfChanges;
        private readonly List<string> changes;

        public Institution(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.numberOfChanges = 0;
            this.changes = new List<string>();
        }

        public int Id { get; }

        public string Name { get; set; }

        public void RegisterInterest(string interest, object entity)
        {
            var entityType = entity.GetType();

            var currentEvent = entityType.GetEvents().FirstOrDefault(x => x.Name.ToLower().Contains(interest));

            if (currentEvent != null)
            {
                var method = typeof(Institution).GetMethod("RegisterChange", 
                    BindingFlags.NonPublic | BindingFlags.Instance);

                var delegateType = currentEvent.EventHandlerType;

                var eventDelegate = Delegate.CreateDelegate(delegateType, this, method);

                currentEvent.AddEventHandler(entity, eventDelegate);
            }
        }

        public string ReportChanges()
        {
            var result = $"{this.Name}: {this.numberOfChanges} changes registered" + Environment.NewLine +
                         string.Join(Environment.NewLine, this.changes);

            return result.Trim();
        }

        private void RegisterChange(object sender, ChangeEventArgs args)
        {
            this.numberOfChanges++;

            var currentChange = $"--{args.Entity}(ID:{args.Id}) changed {args.PropertyName}({args.PropertyType}) from {args.OldValue} to {args.NewValue}";

            this.changes.Add(currentChange);
        }
    }
}