namespace _02.Blobs.Entities.Behaviors
{
    public class Aggressive : Behavior
    {
        private const int AGGRESSIVE_DAMAGE_MULTIPLIER = 2;
        private const int AGGRESSIVE_DAMAGE_DECREMENTER = 5;

        private int sourceInitialDamage;

        private void ApplyTriggerEffect(Blob source)
        {
            source.Damage *= AGGRESSIVE_DAMAGE_MULTIPLIER;
        }

        public override void Trigger(Blob source)
        {
            base.Trigger(source);

            this.sourceInitialDamage = source.Damage;
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
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
                source.Damage -= AGGRESSIVE_DAMAGE_DECREMENTER;

                if (source.Damage <= this.sourceInitialDamage)
                {
                    source.Damage = this.sourceInitialDamage;
                }
            }
        }
    }
}