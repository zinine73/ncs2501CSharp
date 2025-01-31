internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = new string[]{"I", "Love", "Programmers."};
        string[] s2 = new string[]{"m","dot"};
        int[] intarray = new int[]{1, 2, 100, -99, 1, 2, 3};
        string str = "nice to meet you";
        //Console.WriteLine(sol.Solution01272(str));
        //Util.PrintIntArray(sol.Solution0127(s1));

        Sample sam = new Sample();
        foreach (int num in sam.GetNumber())
        {
            //Console.WriteLine(num);
        }
    }
}