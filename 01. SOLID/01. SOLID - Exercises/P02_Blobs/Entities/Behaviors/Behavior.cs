namespace _02.Blobs.Entities.Behaviors
{
    using System;
    using Interfaces;

    public abstract class Behavior : IBehavior
    {
        protected Behavior()
        {
            this.ToDelayRecurrentEffect = true;
        }

        public bool IsTriggered { get; set; }

        public bool ToDelayRecurrentEffect { get; set; }

        public virtual void Trigger(Blob source)
        {
            if (this.IsTriggered)
            {
                throw new InvalidOperationException($"{this.GetType().Name} behavior cannot be triggered twice.");
            }
        }

        public virtual void ApplyRecurrentEffect(Blob source)
        {
            if (!this.IsTriggered)
            {
                throw new InvalidOperationException($"{this.GetType().Name} behavior is not triggered and Recurrent Effect cannot be applied.");
            }
        }
    }
}