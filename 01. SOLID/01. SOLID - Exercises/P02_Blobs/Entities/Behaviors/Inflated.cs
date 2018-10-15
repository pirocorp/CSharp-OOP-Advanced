namespace _02.Blobs.Entities.Behaviors
{
    public class Inflated : Behavior
    {
        private const int INFLATED_HEALTH_BOOSTER = 50;
        private const int INFLATED_HEALTH_DECREMENTER = 10;

        public override void Trigger(Blob source)
        {
            base.Trigger(source);

            this.IsTriggered = true;
            source.Health += INFLATED_HEALTH_BOOSTER;
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
                source.Health -= INFLATED_HEALTH_DECREMENTER;
            }
        }
    }
}