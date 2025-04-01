using MySystem;
internal class Program
{
    private static void Main(string[] args)
    {
        Solution sol = new Solution();
        string[] s1 = ["rabbit04", "98761"];
        string[,] s2 = new string[,]{{"jaja11", "98761"}, {"krong0313", "29440"}, {"rabbit00", "111333"}};
        bool[] b1 = [true, false, true, false, false, true];
        int[] intarray = [6, 1, 5, 2, 3, 4];
        int[,] int2 = new int[,]{{0,1,2},{1,2,3},{2,3,4},{3,4,5}};
        string str = "abc1abc1abc";
        string str1 = "287346502836570928366";
        //Console.WriteLine(sol.Solution0331(str));
        Util.PrintArray(sol.Solution0401(10,20));
        
        //Sample sam = new Sample();
        //sam.Test();
    }

    private void Outer()
    {
        //OuterClass outer = new OuterClass();
        //OuterClass.InnerClass inner = new OuterClass.InnerClass(outer);
        OuterClass.InnerClass inner = new OuterClass.InnerClass(new OuterClass());
        inner.ShowVariable();
        inner.AccessVatiable(60);
        inner.ShowVariable();
    }

    private void Inheritance()
    {
        Child a = new Child(2);
        string name = a.GetName();
        a.SetName("Lee");
        Console.WriteLine($"ori:{name}, after:{a.GetName()}");

        name = a.Name;
        a.Name = "longname";
        Console.WriteLine($"ori:{name}, after:{a.Name}");
    }

    private void Constructor()
    {
        Person p1 = new Person();
        Person p2 = new Person("Lee");

        //Foo foo1 = new Foo() { name = "foo", value = 3 };
        Foo foo1 = new Foo { name = "foo", value = 3 };
        Foo foo2 = new Foo("foo") { value = 3 };

        Foo foo3 = new Foo();
        foo3.name = "foo";
        foo3.value = 3;
        Foo foo4 = new Foo("foo");
        foo4.value = 3;
    }

    private void MethodTest()
    {
        int a = 40;
        int b = 10;
        Console.WriteLine($"Swap before : a={a}, b={b}");
        Swap(ref a, ref b);
        Console.WriteLine($"Swap after : a={a}, b={b}");

        int sum = Add(a, b);
        int aa;
        Add2(out aa);

        int[] intarray = new int[]{7,77,17};
        Console.WriteLine(total(intarray));
        Console.WriteLine(total(7, 77, 17));
        sum = total(1,2,3,4,56,7,8);
    }

    static int total(params int[] list)
    {
        int sum = 0;
        for (int i = 0; i < list.Length; i++)
        {
            sum += list[i];
        }
        return sum;
    }
    static void Add2(out int a)
    {
        a = 100;
    }

    static int Add(int a, int b)
    {
        return a+b;
    }
    static int Add(double a, double b)
    {
        return (int)(a+b);
    }
    static int Add(int a, int b, int c)
    {
        return a+b+c;
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = b;
        b = a;
        a = temp;
    }

    private void InfiniteLoop()
    {
        int sum = 0;
        while (true)
        {
            Console.Write("수를 입력하세요: ");
            string line = Console.ReadLine();
            if (line == "end") break;
            sum += int.Parse(line);
        }
        Console.WriteLine($"지금까지 입력된 수를 모두 더하면 : {sum}");
    }

    private void OperatorSample()
    {
        int a = 1;
        Console.WriteLine(++a);
        Console.WriteLine(a++);
        Console.WriteLine(--a);
        Console.WriteLine(a--);
        Console.WriteLine(a);

        a = 3;
        int b = 5;
        Console.WriteLine(a++ + b); // 8, a=4, b=5
        Console.WriteLine(a++ + --b); // 8, a=5, b=4
        Console.WriteLine(++a + a++); // 12, a=7, b=4
        Console.WriteLine($"a={a}, b={b}");

        Console.WriteLine((a > 4) && (b > 50));

        a = 13;
        b = 10;
        Console.WriteLine(a & b);
        Console.WriteLine(a | b);
        Console.WriteLine(a ^ b);
    }

    private static void FormatString()
    {
        int a = 12345678;
        double b = 12.345678;

        Console.WriteLine($"통화 (C) . . . : {a:C}");
        Console.WriteLine($"10진법 (D) . . : {a:D}");
        Console.WriteLine($"지수표기법 (E) : {b:E}");
        Console.WriteLine($"고정소수점 (F) : {b:F}");
        Console.WriteLine($"일반 (G) . . . : {a:G}");
        Console.WriteLine($"숫자 (N) . . . : {a:N}");
        Console.WriteLine($"16진법 (X) . . : {a:X}");
        Console.WriteLine($"백분율 (P) . . : {b:P}");
        Console.WriteLine("----------------------");
        a = 1234;
        b = 12.345678;
        Console.WriteLine($"0 자리 표시 (0) . . . . : {a:00000}");
        Console.WriteLine($"10진수자리 표시 (#) . . : {a:#####}");
        Console.WriteLine($"소수점 (.) . . . . . . .: {b:0.00000}");
        Console.WriteLine($"천단위자릿수 표시(,) . . : {a:0,0}");
        Console.WriteLine($"백분율 자리 표시 (%) . . : {b:0%}");
        Console.WriteLine($"지수표기법 (e) . . . . . : {b:0.000e+0}");
    }

    private void PartialTest()
    {
        Class1 newClass = new Class1();
        newClass.Get();
        newClass.Put();
        newClass.Run();

        Class2 ccc = new Class2();
        ccc.Run();
    }

    void ExtendTest()
    {
        string s = "This is a Test";
        string s22 = s.ToChangeCase();
        bool found = s.Found('a');
        //bool found = MySystem.ExClass.Found(s, 'a');
        Console.WriteLine($"s22:{s22}, found:{found}");
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