namespace P08_PetClinic.Core
{
    using System;
    using System.Collections.Generic;
    using IO.Interfaces;
    using Models;

    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly Dictionary<string, Pet> pets;
        private readonly Dictionary<string, Clinic> clinics;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;   
            this.writer = writer;

            this.pets = new Dictionary<string, Pet>();
            this.clinics = new Dictionary<string, Clinic>();
        }

        public void Run()
        {
            var n = int.Parse(this.reader.ReadLine());

            for (var i = 0; i < n; i++)
            {
                try
                {
                    this.ProcessCommands();
                }
                catch (Exception e)
                {
                    this.writer.WriteLine($"Invalid Operation!");
                }
            }
        }

        private void ProcessCommands()
        {
            var tokens = this.reader.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var command = tokens[0];

            switch (command)
            {
                case "Create":
                    this.Create(tokens);
                    break;
                case "Add":
                    this.writer.WriteLine(this.Add(tokens));
                    break;
                case "Release":
                    this.writer.WriteLine(this.Release(tokens));
                    break;
                case "HasEmptyRooms":
                    this.writer.WriteLine(this.HasEmptyRooms(tokens));
                    break;
                case "Print":
                    this.Print(tokens);
                    break;
                default:
                    throw new NotSupportedException($"Command: {command} is not supported");
            }
        }

        private void Print(string[] tokens)
        {
            var clinicName = tokens[1];

            if (!this.clinics.ContainsKey(clinicName))
            {
                return;
            }

            var clinic = this.clinics[clinicName];

            if (tokens.Length == 2)
            {
                this.writer.WriteLine(clinic.Print());
                return;
            }

            var roomNumber = int.Parse(tokens[2]) - 1;
            this.writer.WriteLine(clinic.PrintRoom(roomNumber));
        }

        private bool HasEmptyRooms(string[] tokens)
        {
            var clinicName = tokens[1];

            if (!this.clinics.ContainsKey(clinicName))
            {
                return false;
            }

            var clinic = this.clinics[clinicName];

            return clinic.HasEmptyRooms();
        }

        private bool Release(string[] tokens)
        {
            var clinicName = tokens[1];

            if (!this.clinics.ContainsKey(clinicName))
            {
                return false;
            }

            var clinic = this.clinics[clinicName];

            return clinic.Release();
        }

        private bool Add(string[] tokens)
        {
            var petName = tokens[1];
            var clinicName = tokens[2];

            if (!this.pets.ContainsKey(petName))
            {
                return false;
            }

            var pet = this.pets[petName];

            if (!this.clinics.ContainsKey(clinicName))
            {
                return false;
            }

            var clinic = this.clinics[clinicName];
            return clinic.AddPet(pet);
        }

        private void Create(string[] tokens)
        {
            var type = tokens[1];

            if (type == "Pet")
            {
                var name = tokens[2];
                var age = int.Parse(tokens[3]);
                var kind = tokens[4];

                var pet = new Pet(name, age, kind);
                this.pets.Add(name, pet);
            }
            else if (type == "Clinic")
            {
                var name = tokens[2];
                var rooms = int.Parse(tokens[3]);

                var clinic = new Clinic(rooms);
                this.clinics.Add(name, clinic);
            }
        }
    }
}