﻿namespace _02.Blobs.Entities
{
    using System;
    using Events;
    using Interfaces;

    public class Blob
    {
        public event ReportEventHandler ReportEvent;

        private int health;
        private IAttack attack;

        private int initialHealth;
        private int initialDamage;
        private bool isAlive;
        private bool reportEvents;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.attack = attack;

            this.initialHealth = health;
            this.initialDamage = damage;
            this.isAlive = true;
        }

        public string Name { get; private set; }

        public int Health
        {
            get => this.health;
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                if (this.health <= this.initialHealth / 2)
                {
                    this.TriggerBehavior();
                }

                if (this.health == 0)
                {
                    this.isAlive = false;
                    this.ReportEvent?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public IBehavior Behavior { get; private set; }

        public int Damage { get; set; }

        public void Attack(Blob target)
        {
            if (this.isAlive)
            {
                this.attack.Execute(this, target);
            }
        }

        public void Respond(int damage)
        {
            if (this.isAlive)
            {
                this.Health -= damage;
            }
        }

        public void TriggerBehavior()
        {
            if (!this.Behavior.IsTriggered)
            {
                this.Behavior.Trigger(this);
                this.ReportEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Update()
        {
            this.ApplyRecurrentEffect();
        }

        private void ApplyRecurrentEffect()
        {
            if (this.Behavior.IsTriggered)
            {
                this.Behavior.ApplyRecurrentEffect(this);
            }
        }

        public string DetailedInformation()
        {
            //Blob {name} toggled {behavior-type}
            //Blob {name} was killed 

            if (!this.isAlive)
            {
                return $"Blob {this.Name} was killed";
            }

            return $"Blob {this.Name} toggled {this.Behavior.GetType().Name}Behavior";
        }

        public override string ToString()
        {
            //Blob {name}: {health} HP, {damage} Damage
            //Blob {name} KILLED

            if (!this.isAlive)
            {
                return $"Blob {this.Name} KILLED";
            }

            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}