namespace First_Steps
{
    internal class RecursionMethods
    {
        public static void Run()
        {
            Console.WriteLine("Recursion Methods");
            int number = ReadInt("Enter a positive integer to calculate its factorial: ");
            long factorialResult = Factorial(number);
            Console.WriteLine($"Factorial of {number} is: {factorialResult}");
        }
        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a whole number greater than 0.");
            }
        }
        private static long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }
    }
}
