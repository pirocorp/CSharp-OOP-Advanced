﻿namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) 
            : base(name, age, gender, nameof(Frog))
        {
        }

        public override string ProduceSound()
            => "Ribbit";
    }
}
