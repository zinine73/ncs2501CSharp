using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = new string[]{"I", "Love", "Programmers."};
        string[] s2 = new string[]{"m","dot"};
        int[] intarray = new int[]{13, 22, 53, 24, 15, 6};
        string str = "nice to meet you";
        Console.WriteLine(sol.Solution0203(intarray));
        //Util.PrintIntArray(sol.Solution0131(intarray));

        //Sample sam = new Sample();
        //sam.TryCatch();
    }
}