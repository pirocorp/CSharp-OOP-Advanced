namespace ValidationAttributes
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("Galchgo", 32);

            var isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
