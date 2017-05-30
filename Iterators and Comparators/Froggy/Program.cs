using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        public static void Main()
        {
            var lake = new Lake();

            try
            {
                int[] values =
                   Console.ReadLine()
                  .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

                for (int i = 0; i < values.Length; i++)
                {
                    lake.Add(values[i]);
                }

                Console.WriteLine(string.Join(", ", lake));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
