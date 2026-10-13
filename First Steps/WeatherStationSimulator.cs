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
            double[] tempsInCelcius = new double[weekDays];
            double[] tempsInFahrenheit = new double[weekDays];
            for (int i = 0; i < weekDays; i++)
            {
                weatherConditions[i] = conditions[random.Next(conditions.Length)];

                // Random variation between -5 and +5 degrees relative to base temperature
                int variation = random.Next(-5, 6);
                temperatures[i] = celsius + variation;
                tempsInCelcius[i] = temperatures[i];
                double dayFahrenheit = (temperatures[i] * 9 / 5) + 32;
                tempsInFahrenheit[i] = dayFahrenheit;

                Console.WriteLine($"Day {i + 1}: Condition: {weatherConditions[i]}, Temperature: {temperatures[i]}°C ({dayFahrenheit:F1}°F)");
            }

            DisplayAverageTemperature(tempsInCelcius, tempsInFahrenheit);
            DisplayForecast(weatherConditions, tempsInCelcius, tempsInFahrenheit);
            DisplayMaxAndMinTemperature(tempsInCelcius, tempsInFahrenheit);
            DisplayMostFrequentCondition(weatherConditions);
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

        private static void DisplayAverageTemperature(double[] tempsInCelcius, double[] tempsInFahrenheit)
        {
            double averageTemperatureInCelcius = 0;
            double averageTemperatureInFahrenheit = 0;
            foreach (double temp in tempsInCelcius)
            {
                averageTemperatureInCelcius += temp;
            }
            averageTemperatureInCelcius /= tempsInCelcius.Length;
            foreach (double temp in tempsInFahrenheit)
            {
                averageTemperatureInFahrenheit += temp;
            }
            averageTemperatureInFahrenheit /= tempsInFahrenheit.Length;
            Console.WriteLine($"\nAverage Temperature: {averageTemperatureInCelcius:F1}°C ({averageTemperatureInFahrenheit:F1}°F)");
        }

        private static void DisplayForecast(string[] weatherConditions, double[] tempsInCelcius, double[] tempsInFahrenheit)
        {
            Console.WriteLine("\nForecast for the next days:");
            for (int i = 0; i < weatherConditions.Length; i++)
            {
                Console.WriteLine($"Day {i + 1}: Condition: {weatherConditions[i]}, Temperature: {tempsInCelcius[i]}°C ({tempsInFahrenheit[i]:F1}°F)");
            }
        }

        private static void DisplayMaxAndMinTemperature(double[] tempsInCelcius, double[] tempsInFahrenheit)
        {
            double maxTempInCelcius = tempsInCelcius[0];
            double minTempInCelcius = tempsInCelcius[0];
            double maxTempInFahrenheit = tempsInFahrenheit[0];
            double minTempInFahrenheit = tempsInFahrenheit[0];
            foreach (double temp in tempsInCelcius)
            {
                if (temp > maxTempInCelcius) maxTempInCelcius = temp;
                if (temp < minTempInCelcius) minTempInCelcius = temp;
            }
            foreach (double temp in tempsInFahrenheit)
            {
                if (temp > maxTempInFahrenheit) maxTempInFahrenheit = temp;
                if (temp < minTempInFahrenheit) minTempInFahrenheit = temp;
            }
            Console.WriteLine($"\nMaximum Temperature: {maxTempInCelcius:F1}°C ({maxTempInFahrenheit:F1}°F)");
            Console.WriteLine($"Minimum Temperature: {minTempInCelcius:F1}°C ({minTempInFahrenheit:F1}°F)");
        }

        private static void DisplayMostFrequentCondition(string[] weatherConditions)
        {
            var conditionCounts = new Dictionary<string, int>();

            foreach (var condition in weatherConditions)
            {
                if (conditionCounts.ContainsKey(condition))
                {
                    conditionCounts[condition]++;
                }
                else
                {
                    conditionCounts[condition] = 1;
                }
            }

            int maxCount = conditionCounts.Values.Max();

            var mostFrequentConditions = conditionCounts
                .Where(c => c.Value == maxCount);

            Console.WriteLine("\nMost Frequent Condition(s):");

            foreach (var condition in mostFrequentConditions)
            {
                Console.WriteLine($"{condition.Key} ({condition.Value} days)");
            }
        }
    }
}
