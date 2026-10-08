namespace First_Steps
{
    internal class MethodsArgumentPromotions
    {
        public static void Run()
        {
            // Example of method argument promotions
            int intValue = 10;
            double doubleValue = 20.5;
            // Implicit conversion from int to double
            double result = Add(intValue, doubleValue);
            Console.WriteLine($"Result of adding {intValue} and {doubleValue} is: {result}");

            //Argument Promotion in Method Overloading
            int intArg = 5;
            double doubleArg = 10.5;
            Console.WriteLine($"Result of adding {intArg} and {doubleArg} is: {Add(intArg, doubleArg)}");

            float myFloat = 10.5f;
            PrintValue(myFloat); // Promoted to double
            int myInt = 42;
            PrintValue(myInt); // Calls the int overload
        }

        private static double Add(double a, double b)
        {
            return a + b;
        }

        private static void PrintValue(int value)
        {
            Console.WriteLine("Integer: " + value);
        }

        private static void PrintValue(double value)
        {
            Console.WriteLine("Double: " + value);
        }
    }
}
