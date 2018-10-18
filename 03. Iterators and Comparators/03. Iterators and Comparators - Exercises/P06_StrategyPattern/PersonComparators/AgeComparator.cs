namespace P06_StrategyPattern.PersonComparators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}