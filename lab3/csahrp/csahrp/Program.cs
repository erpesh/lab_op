namespace csahrp
{
    class Program
    {
        public static MultiSet CalculateD(MultiSet A, MultiSet B, MultiSet C)
        {
            return (A + B) - C * B;
        }

        public static MultiSet CreateMultiset()
        {
            Console.WriteLine("Enter 1 if you want to create multiset manually and 0 if half-automatically, 2 if automatically");
            var answer = Console.ReadLine();
            
            if (answer == "1")
            {
                return CreateManually();
            }
            
            if (answer == "0")
            {
                return CreateAutomatically();
            }

            if (answer == "2")
            {
                return CreateFullAutomatically();
            }
            
            return CreateMultiset();
        }

        public static MultiSet CreateManually()
        {
            int n;
            Console.WriteLine("Enter size of multiset: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n > 0)
            {
                var array = new char[n];
                for (var i = 0; i < n; i++)
                {
                    array[i] = Console.ReadKey().KeyChar;
                }

                return new MultiSet(array);
            }
            return CreateManually();
        }

        public static MultiSet CreateAutomatically()
        {
            int a, b;
            Console.WriteLine("Enter character range: ");
            Console.WriteLine("a = ");
            int.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("b = ");
            int.TryParse(Console.ReadLine(), out b);

            if (a < b)
            {
                return new MultiSet(a, b);
            }
            return CreateAutomatically();
        }

        public static MultiSet CreateFullAutomatically()
        {
            int n;
            Console.WriteLine("Enter set size:");
            int.TryParse(Console.ReadLine(), out n);
            return new MultiSet(n);
        }

        public static void CheckCharacters(MultiSet D)
        {
            char key = Console.ReadKey().KeyChar;
            if (key == (char)7)
            {
                return;
            }
            Console.WriteLine(D.Includes(key) ? " - includes" : " - excludes");
            CheckCharacters(D);
        }
        
        static void Main(string[] args)
        {
            var A = CreateMultiset();
            Console.WriteLine("\nA:");
            A.OutputSet();
            var B = CreateMultiset();
            Console.WriteLine("\nB:");
            B.OutputSet();
            var C = CreateMultiset();
            Console.WriteLine("\nC:");
            C.OutputSet();
            var D = CalculateD(A, B, C);
            Console.WriteLine("D = (A + B) - C * B = ");
            D.OutputSet();
            Console.WriteLine("Enter character to see if it is in multiset D (enter CTRL + G to complete):");
            CheckCharacters(D);
        }
        
    }
}
