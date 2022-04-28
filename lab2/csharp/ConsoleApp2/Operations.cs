namespace ConsoleApp2;

public class Operations
{

    public static string InnitText(bool randKey)
    {
        return randKey ? InnitRandomText() : InnitUserText();
    }

    private static string InnitRandomText()
    {
        var rand = new Random();
        var length = rand.Next(10, 50);
        var rows = rand.Next(1, 5);
        var text = "";
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < length; j++)
            {
                text += (char)rand.Next(32, 126);
            }
            if (i + 1 < rows)
                text += '\n';
        }

        return text;
    }

    private static string InnitUserText()
    {
        var text = "";
        Console.WriteLine("Enter '-' if you have finished inputting.");
        var input = Console.ReadLine();
        text += input;
        input = Console.ReadLine();
        while (input != "-")
        {
            text += '\n' + input;
            input = Console.ReadLine();
        }

        return text;
    }

    public static TText[] CreateTextArray(int n)
    {
        TText[] texts = new TText[n];
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine("Type 'y' if you want to create random text");
            texts[i] = new TText(InnitText(Console.ReadLine() == "y"));
        }
        
        return texts;
    }

    public static void AddLines(TText[] texts)
    {
        Console.WriteLine("How many texts you want to change?");
        int.TryParse(Console.ReadLine(), out int n);
        if (n <= 0)
        {
            Console.WriteLine("Enter correct number!");
            AddLines(texts);
            return;
        }

        for (var i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter text's number (more than 0, less than {texts.Length + 1}): ");
            int.TryParse(Console.ReadLine(), out int m);
            if (m <= 0 || m > texts.Length)
            {
                Console.WriteLine("Enter correct number!");
                AddLines(texts);
                return;
            }
            Console.WriteLine($"Enter text which you want to add in the text num {i + 1}");
            texts[m - 1].Add(Console.ReadLine());
        } 
        Console.WriteLine();
    }

    public static void FindHighestPercent(TText[] texts)
    {
        double max = 0;
        int maxId = 1;
        for (var i = 0; i < texts.Length; i++)
        {
            var percent = texts[i].DefineConsonantLettersPercent();
            if (percent > max)
            {
                max = percent;
                maxId = i + 1;
            }
        }
        Console.WriteLine($"Highest consonant letters percent is {max}% in {maxId} text.\n");
    }

    public static void OutputTexts(TText[] texts)
    {
        for (var i = 0; i < texts.Length; i++)
        {
            Console.WriteLine($"Text number {i + 1}");
            Console.WriteLine($"Consonant letters percent: {texts[i].DefineConsonantLettersPercent()}%");
            Console.WriteLine($"Text: {texts[i].Text}\n");
        }
    }
}