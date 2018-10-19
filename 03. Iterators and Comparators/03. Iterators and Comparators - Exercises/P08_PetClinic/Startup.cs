namespace P08_PetClinic
{
    using System;
    using Core;
    using IO;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();

            //var pet1 = new Pet("Pesho", 23, "Roshav");
            //var pet2 = new Pet("Gosho", 3, "Pomiqr");
            //var pet3 = new Pet("For Remove", 33, "Dead");

            //var clinic = new Clinic(5);
            //Console.WriteLine(clinic.Print());
            //clinic.AddPet(pet1);
            //Console.WriteLine(clinic.Print());
            //clinic.AddPet(pet2);
            //Console.WriteLine(clinic.Print());
            //clinic.AddPet(pet3);
            //Console.WriteLine(clinic.Print());
            //clinic.Release();
            //Console.WriteLine(clinic.Print());
            //clinic.Release();
            //Console.WriteLine(clinic.Print());
            //clinic.Release();
            //Console.WriteLine(clinic.Print());
        }
    }
}