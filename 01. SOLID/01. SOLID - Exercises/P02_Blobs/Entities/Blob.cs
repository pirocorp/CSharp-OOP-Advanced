namespace _02.Blobs.Entities
{
    using Interfaces;

    public class Blob
    {
        private int health;
        private IAttack attack;

        private int initialHealth;
        private int initialDamage;
        private bool isAlive;

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
            }
        }

        public void Update()
        {
            
        }

        public void ApplyRecurrentEffect()
        {
            if (this.Behavior.IsTriggered)
            {
                this.Behavior.ApplyRecurrentEffect(this);
            }
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"IBlob {this.Name} KILLED";
            }

            return $"IBlob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}