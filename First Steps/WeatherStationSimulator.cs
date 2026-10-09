namespace First_Steps
{
    internal class WeatherStationSimulator
    {
        public static void Run()
        {
            Console.WriteLine("Weather Station Simulator");
            Console.WriteLine("Enter the temperature in Celsius: ");
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                Console.WriteLine($"Temperature in Fahrenheit: {fahrenheit}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }
}
