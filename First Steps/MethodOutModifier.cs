namespace First_Steps
{
    internal class MethodOutModifier
    {
        public static void Run()
        {
            // Example of using the out modifier
            int number;
            Console.WriteLine("Before calling InitializeValue.");
            InitializeValue(out number);
            Console.WriteLine($"After calling InitializeValue: {number}");
        }
        private static void InitializeValue(out int value)
        {
            value = 42; // Must assign a value before returning
        }
    }
}
