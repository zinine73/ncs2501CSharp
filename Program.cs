internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = new string[]{"n","omg"};
        string[] s2 = new string[]{"m","dot"};
        int[] intarray = new int[]{1, 2, 100, -99, 1, 2, 3};
        string str = "I love you~";
        //Console.WriteLine(sol.Solution0122(s1, s2));
        Util.PrintIntArray(sol.Solution0123(15000));

        //Sample sam = new Sample();
        //sam.Operator();
    }
    
}