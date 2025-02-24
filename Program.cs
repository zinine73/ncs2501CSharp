internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = new string[]{"nami", "ahri", "jayce", "garen", "ivern", "vex", "jinx"};
        string[] s2 = new string[]{"m","dot"};
        int[] intarray = new int[]{11,7,4};
        string str = "78720646226947352489";
        //Console.WriteLine(sol.Solution0221(str));
        //Util.PrintIntArray(sol.Solution0224(24));
        Util.PrintArray<int>(sol.Solution0224(29));
        //Util.PrintArray<string>(s1);
        
        //Sample sam = new Sample();
        //sam.Test();
    }

    private void ClassTest()
    {
        Animal anima = new Animal();
        anima.Age = 30;
        anima.Name = "Ani";
        anima.SetSize(3.4f);
        anima.ShowSize();

        Dog puppy = new Dog();
        puppy.Age = 3;
        puppy.Name = "Puppy";
        puppy.HowOld();
        puppy.SetSize(1.2f);
        puppy.ShowSize();

        Bird sae = new Bird();
        sae.Name = "Jack";
        sae.Age = 10;
        sae.Fly();

        NewPices np = new NewPices();
        np.Age = 100;
        np.Name = "ET";
        np.SetSize(200f);
        np.ShowSize();

        //PureBase pb = new PureBase();
        ChildA ca = new ChildA();
        ca.GetFirst();
        ca.GetNext();
    }

    private static void IndexerSample()
    {
        MyClass cls = new MyClass();
        cls.SetName("KIM");
        cls[1] = 1024;
        int i = cls[1];
        int ii = cls["KIM"];
        cls["LEE"] = 3;
    }

    void EventSample()
    {
        MyButton btn = new MyButton();
        btn.Click += new EventHandler(btn_Click);
        btn.Click += new EventHandler(btn_down);
        btn.Click -= new EventHandler(btn_Click);
        btn.Text = "Run";
        btn.MouseButtonDown();
    }

    static void btn_Click(object sender, EventArgs e)
    {
        Console.WriteLine("button click");
    }

    static void btn_down(object sender, EventArgs e)
    {
        Console.WriteLine("button down");
    }

    private void MethodSample()
    {
        Sample sam = new Sample();

        sam.Method1("LEE", 12, 12);
        sam.Method1("KIM", score:10, age:12);
        sam.Method1("PARK", child:1, age:30, score:20);

        Console.WriteLine(sam.Calc2(1,2,3,4));
        Console.WriteLine(sam.Calc2(6,7,8,9,10,11));
    }

    private void refout()
    {
        // ref : 초기화 필요
        int x = 1;
        double y = 1.0;
        double ret = GetData(ref x, ref y);
        
        // out : 초기화 불필요
        int c, d;
        bool bret = GetData(10, 20, out c, out d);
    }

    static double GetData(ref int a, ref double b)
    {
        return ++a * ++b;
    }

    static bool GetData(int a, int b, out int c, out int d)
    {
        c = a + b;
        d = a - b;
        return true;
    }

    private void Calculate(int a)
    {
        Console.WriteLine($"before:{a}");
        a *= 2;
        Console.WriteLine($"after:{a}");
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