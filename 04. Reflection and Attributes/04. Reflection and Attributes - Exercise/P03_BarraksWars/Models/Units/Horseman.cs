namespace P03_BarraksWars.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Horseman : Unit
    {
        private const int DEFAULT_HEALTH = 50;
        private const int DEFAULT_DAMAGE = 10;


        public Horseman() 
            : base(DEFAULT_HEALTH, DEFAULT_DAMAGE)
        {
        }
    }
}