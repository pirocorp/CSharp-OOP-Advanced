namespace _02.Blobs.Entities.Behaviors
{
    using System;
    using Interfaces;

    public abstract class Behavior : IBehavior
    {
        private bool toDelayRecurrentEffect;

        protected Behavior()
        {
            this.toDelayRecurrentEffect = true;
        }

        public bool IsTriggered { get; set; }

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

        protected bool ToDelayRecurrentEffect
        {
            get => this.toDelayRecurrentEffect;
            set => this.toDelayRecurrentEffect = value;
        }
    }
}