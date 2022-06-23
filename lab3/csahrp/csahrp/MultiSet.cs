namespace csahrp;

public class MultiSet
{
    private char[] symbols { get; }

    public void OutputSet()
    {
        var output = "";
        foreach (var chr in symbols)
        {
            output += chr;
        }
        Console.WriteLine(output);
        Console.WriteLine();
    }

    public MultiSet(char[] characters)
    {
        symbols = characters;
    }

    public MultiSet(int a, int b)
    {
        var characters = new char[b - a];
        var index = 0;
        for (var i = a; i < b; i++)
        {
            characters[index] = (char)i;
            index++;
        }

        symbols = characters;
    }

    public MultiSet(int n)
    {
        var characters = new char[n];
        var rand = new Random();
        for (var i = 0; i < n; i++)
        {
            characters[i] = (char)rand.Next(32, 127);
        }

        symbols = characters;
    }

    public static MultiSet operator +(MultiSet a, MultiSet b)
    {
        var union = a.symbols.Union(b.symbols);
        return new MultiSet(union.ToArray());
    }

    public static MultiSet operator *(MultiSet a, MultiSet b)
    {
        var intersect = a.symbols.Intersect(b.symbols);
        return new MultiSet(intersect.ToArray());
    }

    public static MultiSet operator -(MultiSet a, MultiSet b)
    {
        var diff = a.symbols.Except(b.symbols);
        return new MultiSet(diff.ToArray());
    }

    public bool Includes(char chr)
    {
        foreach (var symbol in symbols)
        {
            if (symbol == chr) return true;
        }

        return false;
    }
}