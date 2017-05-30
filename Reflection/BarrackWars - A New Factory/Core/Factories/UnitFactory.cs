namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3
            string className = unitType;
            string namespaceName = "_03BarracksFactory.Models.Units";
            var unit = (IUnit)Activator.CreateInstance(Type.GetType(namespaceName + "." + className));

            return unit;
        }
    }
}
