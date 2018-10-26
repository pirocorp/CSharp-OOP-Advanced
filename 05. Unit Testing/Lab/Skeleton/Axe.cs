﻿using System;

// Axe durability drop with 5 
namespace Skeleton
{
    public class Axe
    {
        private readonly int attackPoints;
        private int durabilityPoints;

        public Axe(int attack, int durability)
        {
            this.attackPoints = attack;
            this.durabilityPoints = durability;
        }

        public int AttackPoints => this.attackPoints;

        public int DurabilityPoints => this.durabilityPoints;

        public void Attack(Dummy target)
        {
            if (this.durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(this.attackPoints);
            this.durabilityPoints -= 1;
        }
    }
}
