using System.Globalization;
using System.Linq;
using System.Reflection;
using _03BarracksFactory.Core.Commands;

namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = this.InterpredCommand(data, commandName).Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private IExecutable InterpredCommand(string[] data, string commandName)
        {
            var typeOfCommand = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name ==
                                     CultureInfo.CurrentCulture
                                     .TextInfo.ToTitleCase(commandName.ToLower()) + "Command");

            var command = (IExecutable)Activator.CreateInstance(
                typeOfCommand, data, this.repository, this.unitFactory);

            return command;
        }
    }
}
