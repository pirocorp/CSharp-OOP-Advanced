namespace Animals
{
    using System;

    public abstract class Animal : IAnimal
    {
        private string gender;
        private int age;

        protected Animal(string name, int age, string gender, string animalType)
        {
            if (age < 0)
            {
                throw new Exception("Invalid input!");
            }

            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.AnimalType = animalType;
        }

        public string Name { get; private set; }

        public int Age
        {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            set
            {
                if (!value.Equals("Male") && !value.Equals("Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public string AnimalType { get; private set; }

        public abstract string ProduceSound();

        public override string ToString()
            => $"{this.Name} {this.Age} {this.Gender}";
    }
}
