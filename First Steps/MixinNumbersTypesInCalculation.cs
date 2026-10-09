namespace First_Steps
{
    internal class MixinNumbersTypesInCalculation
    {
        public static void Run()
        {
            Console.WriteLine("Mixing Numbers Types in Calculation");
            int intValue = 10;
            double doubleValue = 5.5;
            // Mixing int and double in a calculation
            double result = intValue + doubleValue;
            Console.WriteLine($"Result of adding int ({intValue}) and double ({doubleValue}): {result}");

            // Mixing int and double in a multiplication
            result = intValue * doubleValue;
            Console.WriteLine($"Result of multiplying int ({intValue}) and double ({doubleValue}): {result}");

            // Mixing int and double in a division
            result = intValue / doubleValue;
            Console.WriteLine($"Result of dividing int ({intValue}) by double ({doubleValue}): {result}");

            // You cannot assign a double to an int without explicit casting
        }
    }
}
