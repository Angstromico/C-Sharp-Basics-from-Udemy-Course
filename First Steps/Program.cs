namespace First_Steps
{
    class Program
    {
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

            Console.ReadKey();
        }
    }
}