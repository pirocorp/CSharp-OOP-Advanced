namespace P06_1984.Entities.EventArgs
{
    using System;

    public class ChangeEventArgs: EventArgs
    {
        public ChangeEventArgs(string id, string entity, string propertyType, string propertyName, string oldValue, string newValue)
        {
            this.Id = id;
            this.Entity = entity;
            this.PropertyType = propertyType;
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string Id { get; set; }

        public string Entity { get; }

        public string PropertyType { get; }

        public string PropertyName { get; }

        public string OldValue { get; }

        public string NewValue { get; }
    }
}