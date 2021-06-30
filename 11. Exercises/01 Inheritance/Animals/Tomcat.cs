namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) 
            : base(name, age, "Male", nameof(Tomcat))
        {
        }

        public override string ProduceSound()
            => "MEOW";
    }
}
