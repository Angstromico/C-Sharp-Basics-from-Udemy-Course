namespace First_Steps
{
    class Program
    {

        //Instance variable: 
        int instanceVariable;
        static void Main(string[] args)
        {
            //Message
            Console.WriteLine("Please enter a message: ");
            string? userMessage = Console.ReadLine();
            Console.WriteLine("You entered: " + userMessage);

            CharsExamples.Run();
            Calculator.Run();
            Conversions.Run();
            StringBinds.Run();
            ReferencesEquals.Run();
            RandomExample.Run();
            SimpleCalculator.Run();
            CountdownForLoop.Run();
            GuessNumberWhileLoop.Run();
            TwoAndThreeDimensinalArraysExamples.Run();
            JaggedArrays.Run();
            MethodsArgumentPromotions.Run();
            MethodRefModifier.Run();
            MethodOutModifier.Run();
            MethodInModifier.Run();
            WeatherStationSimulator.Run();
            MixinNumbersTypesInCalculation.Run();

            var program = new Program();

            Console.WriteLine($"Instance variable value before: {program.instanceVariable}");

            program.IncreaseInstanceVariable();
            Console.WriteLine($"Instance variable value after: {program.instanceVariable}");

            Console.ReadKey();
        }

        int IncreaseInstanceVariable()
        {
            instanceVariable++;
            return instanceVariable;
        }
    }
}
