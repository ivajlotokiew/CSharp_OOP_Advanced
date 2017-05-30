using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Assembly.GetEntryAssembly()
                .GetTypes().FirstOrDefault(t => t.Name == unitType);

            var createUnit = (IUnit)Activator.CreateInstance(type);

            return createUnit;
        }
    }
}
