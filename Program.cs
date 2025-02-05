using System.Security.Cryptography;

internal class Program
{
    struct MyPoint
    {
        public int X;
        public int y;
        public MyPoint(int x, int y)
        {
            X = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"({X}, {y})";
        }
    }

    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = new string[]{"I", "Love", "Programmers."};
        string[] s2 = new string[]{"m","dot"};
        int[] intarray = new int[]{0, 1, 0, 10, 0, 1, 0, 10, 0, -1, -2, -1};
        string str = "wsdawsdaxssw";
        Console.WriteLine(sol.Solution0205(91,2));
        //Util.PrintIntArray(sol.Solution0131(intarray));

        //Sample sam = new Sample();
        //sam.TryCatch();

        //MyPoint pt = new MyPoint(10, 12);
        //Console.WriteLine(pt.ToString());
    }
}