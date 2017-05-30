namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            Type type = typeof(BlackBoxInt);
            BlackBoxInt instance = (BlackBoxInt)Activator.CreateInstance(type, true);

            string input = Console.ReadLine();

            while (input != "END")
            {
                ExecuteMethodOperation(input, instance);
                Console.WriteLine(GetInstanceField(typeof(BlackBoxInt), instance, "innerValue"));
                input = Console.ReadLine();
            }
        }

        private static void ExecuteMethodOperation(string input, BlackBoxInt instance)
        {
            string[] info = input.Split('_');
            string method = info[0];
            int value = int.Parse(info[1]);

            switch (method)
            {
                case "Add":
                    var addMethod = typeof(BlackBoxInt).GetMethod("Add",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    addMethod.Invoke(instance, new object[] { value });
                    break;
                case "Subtract":
                    var subtractMethod = typeof(BlackBoxInt).GetMethod("Subtract",
                         BindingFlags.NonPublic | BindingFlags.Instance);
                    subtractMethod.Invoke(instance, new object[] { value });
                    break;
                case "Multiply":
                    var multiplyMethod = typeof(BlackBoxInt).GetMethod("Multiply",
                         BindingFlags.NonPublic | BindingFlags.Instance);
                    multiplyMethod.Invoke(instance, new object[] { value });
                    break;
                case "Divide":
                    var divideMethod = typeof(BlackBoxInt).GetMethod("Divide",
                         BindingFlags.NonPublic | BindingFlags.Instance);
                    divideMethod.Invoke(instance, new object[] { value });
                    break;
                case "LeftShift":
                    var lShiftMethod = typeof(BlackBoxInt).GetMethod("LeftShift",
                         BindingFlags.NonPublic | BindingFlags.Instance);
                    lShiftMethod.Invoke(instance, new object[] { value });
                    break;
                case "RightShift":
                    var rShifMethod = typeof(BlackBoxInt).GetMethod("RightShift",
                         BindingFlags.NonPublic | BindingFlags.Instance);
                    rShifMethod.Invoke(instance, new object[] { value });
                    break;
                default:
                    break;
            }
        }

        private static object GetInstanceField(Type type, BlackBoxInt instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static;
            FieldInfo field = type.GetField(fieldName, bindFlags);

            return field.GetValue(instance);
        }
    }
}
