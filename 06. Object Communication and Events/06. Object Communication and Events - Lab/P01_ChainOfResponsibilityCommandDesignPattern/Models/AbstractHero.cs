namespace ObjectCommunicationAndEventsLab.Models
{
    using Enums;
    using Interfaces;

    public abstract class AbstractHero : IAttacker, IObserver
    {
        private const string TARGET_NULL_MESSAGE = "Target is null.";
        private const string NO_TARGET_MESSAGE = "{0} has no newTarget.";
        private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
        private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

        private int damage;
        private readonly string id;
        private readonly IHandler logger;
        private ITarget target;

        protected AbstractHero(string id, int damage, IHandler logger)
        {
            this.id = id;
            this.damage = damage;
            this.logger = logger;
        }

        public void Attack()
        {
            if (this.target == null)
                this.logger.Handle(LogType.Error, string.Format(NO_TARGET_MESSAGE, this));
            else if (this.target.IsDead)
                this.logger.Handle(LogType.Error, string.Format(TARGET_DEAD_MESSAGE, this.target));
            else
                this.ExecuteClassSpecificAttack(this.target, this.damage);
        }

        public void SetTarget(ITarget newTarget)
        {
            if (newTarget == null)
            {
                this.logger.Handle(LogType.Error, string.Format(TARGET_NULL_MESSAGE));
            }
            else
            {
                this.target = newTarget;
                this.logger.Handle(LogType.Target, string.Format(SET_TARGET_MESSAGE, this, newTarget));
            }
        }

        public void Update(int val)
        {
            this.damage += val;
        }

        protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

        public override string ToString()
        {
            return this.id;
        }
    }
}