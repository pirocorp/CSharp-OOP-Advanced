namespace P03_BarraksWars.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gunner : Unit
    {
        private const int DEFAULT_HEALTH = 20;
        private const int DEFAULT_DAMAGE = 20;

        public Gunner() 
            : base(DEFAULT_HEALTH, DEFAULT_DAMAGE)
        {
        }
    }
}