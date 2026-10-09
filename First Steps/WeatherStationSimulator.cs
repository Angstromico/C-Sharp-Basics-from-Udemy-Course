namespace First_Steps
{
    internal class WeatherStationSimulator
    {
        public static void Run()
        {
            Console.WriteLine("Weather Station Simulator");

            int weekDays = ReadInt("Enter the number of days: ");
            Console.WriteLine($"Number of days: {weekDays}");

            double celsius = ReadDouble("Enter the temperature in Celsius: ");
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit}");
        }

        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);

                string? input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }

        private static double ReadDouble(string message)
        {
            while (true)
            {
                Console.WriteLine(message);

                string? input = Console.ReadLine();

                if (double.TryParse(input, out double result))
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }


    }
}
