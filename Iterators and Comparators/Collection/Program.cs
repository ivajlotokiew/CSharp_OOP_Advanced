using System;

namespace FirstTask
{
    public class Program
    {
        public static void Main()
        {
            var newCollection = new ListyIterator<string>();
            try
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input.Length > 1)
                {
                    for (var i = 1; i < input.Length; i++)
                    {
                        newCollection.Add(input[i]);
                    }
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    switch (command)
                    {
                        case "HasNext":
                            Console.WriteLine(newCollection.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(newCollection.Move());
                            break;
                        case "Print":
                            newCollection.Print();
                            break;
                        case "PrintAll":
                            newCollection.PrintAll();
                            break;
                    }

                    command = Console.ReadLine();
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
