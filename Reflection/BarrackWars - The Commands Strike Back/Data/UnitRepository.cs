﻿namespace _03BarracksFactory.Data
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Text;
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
                StringBuilder statBuilder = new StringBuilder();

                foreach (var entry in amountOfUnits)
                {
                    string formatedEntry =
                        string.Format($"{entry.Key} -> {entry.Value}");
                    statBuilder.AppendLine(formatedEntry);
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

        public string RemoveUnit(string unitType)
        {
            if (!this.amountOfUnits.ContainsKey(unitType) || this.amountOfUnits[unitType] == 0)
            {
                return "No such units in repository.";
            }

            this.amountOfUnits[unitType]--;

            return unitType + " retired!";
        }
    }
}
