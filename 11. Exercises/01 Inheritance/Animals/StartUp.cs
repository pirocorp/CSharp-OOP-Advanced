namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<IAnimal>();

            var animalType = string.Empty;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                var inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                var name = inputArgs[0];
                var age = int.Parse(inputArgs[1]);
                var gender = inputArgs.Length == 3 ? inputArgs[2] : string.Empty;

                if (age < 0)
                {
                    Console.WriteLine($"Invalid input!");
                    continue;
                }

                var animal = InstantiateAnimal(animalType, name, age, gender);
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.AnimalType);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }

        private static IAnimal InstantiateAnimal(string animalTypeName, string name, int age, string gender)
        {
            var animalType = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(animalTypeName));

            var parameters = new List<object> { name, age };

            if (gender != string.Empty)
            {
                parameters.Add(gender);
            }

            var parametersTypes = parameters
                .Select(p => p.GetType()).ToArray();

            var constructor = animalType.GetConstructor(parametersTypes);

            return (IAnimal) constructor.Invoke(parameters.ToArray());
        }
    }
}
