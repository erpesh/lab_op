namespace ConsoleApp2;

public class TText
{
    public string Text { get; set; }

    public TText(string text)
    {
        Text = text;
    }

    public void Add(string textToAdd)
    {
        Text = Text + "\n" + textToAdd;
    }

    public double DefineConsonantLettersPercent()
    {
        var vowels = "aeiouAEIOU";
        var countVowels = 0;
        var countConsonants = 0;
        foreach (var chr in Text)
        {
            if ((chr >= 'a' && chr <= 'z') || (chr >= 'A' && chr <= 'Z'))
            {
                if (vowels.Contains(chr)) countVowels++;
                else countConsonants++;
            }
        }

        return 100 * (countConsonants / (double)(countConsonants + countVowels));
    }
}