namespace First_Steps
{
    internal class MethodRefModifier
    {
        public static void Run()
        {
            // Example of using the ref modifier
            int number = 5;
            Console.WriteLine($"Before calling ModifyValue: {number}");
            ModifyValue(ref number);
            Console.WriteLine($"After calling ModifyValue: {number}");
        }

        private static void ModifyValue(ref int value)
        {
            value = 10;
        }
    }
}
