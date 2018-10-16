namespace P08_CustomListSorter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Sorter
    {
        public static void Sort<T>(ICustomList<T> inputList)
            where T : IComparable<T>
        {
            var sorted = inputList.OrderBy(e => e).ToList();

            for (var i = 0; i < sorted.Count; i++)
            {
                inputList[i] = sorted[i];
            }
        }
    }
}