﻿internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = new string[]{"I", "Love", "Programmers."};
        string[] s2 = new string[]{"m","dot"};
        int[] intarray = new int[]{10,8,6};
        string str = "00854020";
        //Console.WriteLine(sol.Solution02112(str));
        Util.PrintIntArray(sol.Solution02112(15));

        //Sample sam = new Sample();
        //sam.TryCatch();
    }

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

    private static void Example()
    {
        //MyPoint pt = new MyPoint(10, 12);
        //Console.WriteLine(pt.ToString());

        MyCustomer myc = new MyCustomer(10);
        MyCustomer myc2 = new MyCustomer();

        // 필드를 public 으로 하면 위험
        // 원치 않는 값지정등을 외부에서 할 수 있기 때문
        //myc.yearmoney = -1000;
        //myc.SetYearMoney(-1000);
        myc.Age = 10;
        myc.YearMoney = -1000;
        myc.printYearMoney();

        myc.Init("lee",20);
    }
}