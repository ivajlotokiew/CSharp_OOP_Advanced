using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            var stackCollection = new StackCollection<int>();

            try
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < input.Length; i++)
                {
                    stackCollection.Push(int.Parse(input[i]));
                }

                string line = Console.ReadLine();

                while (line != "END")
                {
                    string[] data = line.Split();
                    string command = data[0];

                    switch (command)
                    {
                        case "Push":
                            int element = int.Parse(data[1]);
                            stackCollection.Push(element);
                            break;
                        case "Pop":
                            stackCollection.Pop();
                            break;
                        default:
                            throw new ArgumentException("There is no such command.");
                    }

                    line = Console.ReadLine();
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            foreach (var element in stackCollection)
            {
                Console.WriteLine(element);
            }
        }
    }
}
