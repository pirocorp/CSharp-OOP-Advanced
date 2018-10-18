namespace P06_StrategyPattern.PersonComparators
{
    using System.Collections.Generic;

    public class NameLengthComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length != y.Name.Length)
            {
                return x.Name.Length - y.Name.Length;
            }

            return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
        }
    }
}