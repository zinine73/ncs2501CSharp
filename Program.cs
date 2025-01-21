internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        int[] intarray = new int[]{1, 2, 100, -99, 1, 2, 3};
        string str = "I love you~";
        //Console.WriteLine(sol.Solution0120(4,12));
        Util.PrintIntArray(sol.Solution0121(intarray));

        //Sample sam = new Sample();
        //sam.StringBuilderSample();
    }
    
}