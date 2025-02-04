using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = new string[]{"I", "Love", "Programmers."};
        string[] s2 = new string[]{"m","dot"};
        int[] intarray = new int[]{0, 1, 0, 10, 0, 1, 0, 10, 0, -1, -2, -1};
        string str = "wsdawsdaxssw";
        Console.WriteLine(sol.Solution02042(intarray));
        //Util.PrintIntArray(sol.Solution0131(intarray));

        //Sample sam = new Sample();
        //sam.TryCatch();
    }
}