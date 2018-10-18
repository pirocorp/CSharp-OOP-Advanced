namespace P05_ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        public int CompareTo(Person other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            var nameComparison = string.Compare(this.Name, other.Name, StringComparison.Ordinal);

            if (nameComparison != 0)
            {
                return nameComparison;
            }

            var ageComparison = this.Age.CompareTo(other.Age);

            if (ageComparison != 0)
            {
                return ageComparison;
            }

            return string.Compare(this.Town, other.Town, StringComparison.Ordinal);
        }
    }
}