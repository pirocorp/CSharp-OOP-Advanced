namespace P07_EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public int CompareTo(Person other)
        {
            var ageComparator = this.Age.CompareTo(other.Age);

            if (ageComparator != 0)
            {
                return ageComparator;
            }

            return this.Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person person))
            {
                return false;
            }

            if (this.Name != person.Name)
            {
                return false;
            }

            if (this.Age != person.Age)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var nameHashCode = this.Name.GetHashCode();
            var ageHashCode = this.Age.GetHashCode();

            var result = nameHashCode ^ ageHashCode;

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}