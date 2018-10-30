namespace ObjectCommunicationAndEventsLab.Models
{
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    public class Dragon : ITarget, ISubject
    {
        private const string THIS_DIED_EVENT = "{0} dies";

        private readonly string id;
        private int hp;
        private readonly int reward;
        private bool eventTriggered;
        private readonly IHandler eventLogger;
        private readonly List<IObserver> observers;

        public Dragon(string id, int hp, int reward, IHandler eventLogger)
        {
            this.id = id;
            this.hp = hp;
            this.reward = reward;
            this.eventLogger = eventLogger;
            this.observers = new List<IObserver>();
        }

        public bool IsDead => this.hp <= 0;

        public void NotifyObservers()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.Update(this.reward);
            }
        }

        public void ReceiveDamage(int damage)
        {
            if (!this.IsDead)
            {
                this.hp -= damage;
            }

            if (this.IsDead && !this.eventTriggered)
            {
                this.eventLogger.Handle(LogType.Event, string.Format(THIS_DIED_EVENT, this));
                this.eventTriggered = true;
            }
        }

        public void Register(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public override string ToString()
        {
            return this.id;
        }

        public void Unregister(IObserver observer)
        {
            this.observers.Remove(observer);
        }
    }
}