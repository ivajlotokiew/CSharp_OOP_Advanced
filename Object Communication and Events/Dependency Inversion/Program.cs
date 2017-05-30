using System;
using _03DependencyInversion.Models;

namespace _03DependencyInversion
{
    public class Program
    {
        public static void Main()
        {
            var primitiveCalculator = new PrimitiveCalculator();

            var line = Console.ReadLine();

            if (line.Split()[0] != "mode")
            {
                int firstOperand = int.Parse(line.Split()[0]);
                int secondOperand = int.Parse(line.Split()[1]);
                Console.WriteLine(primitiveCalculator
                    .PerformCalculation(firstOperand, secondOperand));


                line = Console.ReadLine();
            }

            while (line != "End")
            {
                string[] data = line.Split();

                if (data[0] != "mode")
                {
                    int firstOperand = int.Parse(data[0]);
                    int secondOperand = int.Parse(data[1]);

                    Console.WriteLine(primitiveCalculator
                        .PerformCalculation(firstOperand, secondOperand));
                }
                else
                {
                    var sign = data[1].ToCharArray();
                    primitiveCalculator.ChangeStrategy(sign[0]);
                }

                line = Console.ReadLine();
            }
        }
    }
}
