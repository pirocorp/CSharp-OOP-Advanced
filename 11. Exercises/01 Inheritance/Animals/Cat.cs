namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) 
            : base(name, age, gender, nameof(Cat))
        {
        }

        protected Cat(string name, int age, string gender, string animalType)
            : base(name, age, gender, animalType)
        {
        }

        public override string ProduceSound()
            => "Meow meow";
    }
}
