namespace _02.Blobs.Entities.Behaviors
{
    using System;

    public class Inflated : Behavior
    {
        public override void Trigger(Blob source)
        {
            base.Trigger(source);

            this.IsTriggered = true;
            source.Health += 50;
        }

        public override void ApplyRecurrentEffect(Blob source)
        {
            base.ApplyRecurrentEffect(source);

            if (this.ToDelayRecurrentEffect)
            {
                this.ToDelayRecurrentEffect = false;
            }
            else
            {
                source.Health -= 10;
            }
        }
    }
}