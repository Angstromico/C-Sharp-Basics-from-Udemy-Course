namespace First_Steps
{
    internal class WeatherStationSimulator
    {
        public static void Run()
        {
            Console.WriteLine("Weather Station Simulator");

            int weekDays = ReadInt("Enter the number of days: ");
            Console.WriteLine($"Number of days: {weekDays}");

            double celsius = ReadDouble("Enter the base temperature in Celsius: ");
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine($"Base temperature: {celsius}°C ({fahrenheit:F1}°F)\n");

            string[] conditions = ["Sunny", "Cloudy", "Snowy", "Rainy"];
            Random random = new();

            double[] temperatures = new double[weekDays];
            string[] weatherConditions = new string[weekDays];

            Console.WriteLine("Forecast for the next days:");
            for (int i = 0; i < weekDays; i++)
            {
                weatherConditions[i] = conditions[random.Next(conditions.Length)];

                // Random variation between -5 and +5 degrees relative to base temperature
                int variation = random.Next(-5, 6);
                temperatures[i] = celsius + variation;
                double dayFahrenheit = (temperatures[i] * 9 / 5) + 32;

                Console.WriteLine($"Day {i + 1}: Condition: {weatherConditions[i]}, Temperature: {temperatures[i]}°C ({dayFahrenheit:F1}°F)");
            }
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
