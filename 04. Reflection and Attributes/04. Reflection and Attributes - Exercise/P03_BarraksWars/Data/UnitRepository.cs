namespace P03_BarraksWars.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class UnitRepository : IRepository
    {
        private readonly IDictionary<string, int> amountOfUnits;

        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                var statBuilder = new StringBuilder();
                foreach (var entry in this.amountOfUnits)
                {
                    var formattedEntry = string.Format($"{entry.Key} -> {entry.Value}");
                    statBuilder.AppendLine(formattedEntry);
                }

                return statBuilder.ToString().Trim();
            }
        }

        public void AddUnit(IUnit unit)
        {
            var unitType = unit.GetType().Name;
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            if (!this.amountOfUnits.ContainsKey(unitType) || this.amountOfUnits[unitType] == 0)
            {
                throw new ArgumentException("No such units in repository.");
            }

            this.amountOfUnits[unitType]--;
        }
    }
}
