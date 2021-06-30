namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) 
            : base(name, age, "Female", nameof(Kitten))
        {
        }

        public override string ProduceSound()
            => "Meow";
    }
}
