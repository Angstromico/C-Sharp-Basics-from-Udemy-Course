namespace First_Steps
{
    internal class MethodInModifier
    {
        public static void Run()
        {
            // Example of using the in modifier
            int number = 5;
            Console.WriteLine($"Before calling DisplayValue: {number}");
            DisplayValue(in number);
            Console.WriteLine($"After calling DisplayValue: {number}");
        }
        private static void DisplayValue(in int value)
        {
            Console.WriteLine($"Value inside DisplayValue: {value}");
            // value = 10; // This line would cause a compile-time error because 'value' is read-only
        }
    }
}
