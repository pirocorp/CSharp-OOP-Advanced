namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (value == null || value.Length < 3)
                {
                    throw new ArgumentException($"{nameof(Name)}'s length should not be less than 3 symbols!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString();

        }
    }
}
