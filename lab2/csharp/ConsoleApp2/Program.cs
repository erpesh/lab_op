
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("Enter number of texts: ");
            int.TryParse(Console.ReadLine(), out var n);
            if (n == 0)
            {
                Console.WriteLine("Enter correct number.");
                return;
            }
            TText[] texts = Operations.CreateTextArray(n);
            Operations.AddLines(texts);
            Operations.OutputTexts(texts);
            Operations.FindHighestPercent(texts);
        }
    }
}