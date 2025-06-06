#define TEST_ENV
#define NINTENDO // ANDROID

using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

public partial class Class2
{
    public void Run()
    {
        DoThis();
    }

    partial void DoThis();
} 

partial class Class1
{
    public void Run() {}
}

partial struct Struct1
{
    public int ID;
}

partial interface IDoable
{
    string Name {get; set;}
}

class Sample
{
    // lambda 
    public void lambdaSample()
    {
        //string str;
        //(str) => { Console.WriteLine(str); } ;
        //(p) => Write(p);
        //(string s, int e) => { Console.WriteLine(s); Console.WriteLine(e); }

        //this.button1.Click += new System.EventHandler(button1_Click);
        //this.button1.Click += button1_Click;
        //this.button1.Click += delegate(object sender, EventArgs e)
        //{
        //    ((Button)sender).BackColor = Color.Red;
        //};
        //this.button1.Click += (sender, e) => ((Button)sender).BackColor = Color.Red;
    }

    //private void button1_Click(object sender, EventArgs e)
    //{
    //    ((Button)sender).BackColor = Color.Red;
    //}

    private void Write(string s, int e)
    {
        Console.WriteLine(s);
        Console.WriteLine(e);
    }

    // delegate 정의
    delegate int MyDelegate(string s);

    public void Test()
    {
        // delegate 개체 생성
        MyDelegate m = new MyDelegate(StringToInt);
        // delegate 객체를 메서드로 전달
        Run(m);
    }

    // 대상 메서드
    int StringToInt(string s)
    {
        return int.Parse(s);
    }

    // 전달받는 메서드
    void Run(MyDelegate method)
    {
        int i = method("123");
        Console.WriteLine(i);
    }

    #region Public
    public int abc;
    public float cde;
    #endregion Public

    #region Private
    private int nnn;
    private bool jijij;
    private bool testEnv;
    #endregion

    #region Property
    public int ABC { get; set;}
    #endregion
    
    #region Method
    public void Run(){}
    public void Create(){}
    #endregion

    public void PreProcess()
    {
#if (TEST_ENV)
        Console.WriteLine("Now Test env.");
    #if (ANDROID)
        Console.WriteLine("platform : android");
    #elif (IOS)
        Console.WriteLine("platform : IOS");
    #elif (NINTENDO)
        Console.WriteLine("platform : NINTENDO");
    #else
        Console.WriteLine("platform : PC");
    #endif
#else
        Console.WriteLine("Now Production env.");
#endif
    }

    public int Calc2(params int[] values)
    {
        int answer = 0;
        foreach (var item in values)
        {
            answer += item;
        }
        return answer;
    }

    public int Calc(int a, int b, string calcType = "+")
    {
        switch (calcType)
        {
            case "+": return a + b;
            case "-": return a - b;
            case "*": return a * b;
            case "/": return a / b;
            default: throw new ArithmeticException();
        }
    }

    public void Method1(string name, int age, int score, int child = 0)
    {

    }

    public void NullableTest()
    {
        int? a = null;
        int? b = 0;
        int result = Nullable.Compare<int>(a, b);
        Console.WriteLine(result);

        double? c = 0.01;
        double? d = 0.0100;
        bool result2 = Nullable.Equals<double>(c, d);
        Console.WriteLine(result2);
    }

    float sum = 0;
    DateTime time;
    bool? selected;

    /// <summary>
    /// 인풋 값 체크
    /// </summary>
    /// <param name="i"></param>
    /// <param name="d">null값 가질 수 있음</param>
    /// <param name="time"></param>
    /// <param name="selected"></param>
    /// <exception cref="ArgumentException"></exception>
    public void CheckInput(int? i, float? d, DateTime? time, bool? selected)
    {
        if (i.HasValue && d.HasValue)
        {
            this.sum = (float)i.Value + (float)d.Value;
        }

        if (!time.HasValue)
            throw new ArgumentException();
        else
            this.time = time.Value;

        //this.selected = selected ?? false;
        if (selected == null)
            this.selected = false;
        else
            this.selected = selected;
    }

    public void NullableSample()
    {
        int i = 0;
        int? ii = null;
        bool? b = null;
        int?[] a = new int?[100];

        if (ii != null)
        {
            Console.WriteLine(i);
        }
    }

    public void TryCatch()
    {
        int[] intarray = new int[]{1,2,3,4};
        // try-catch 없이 실행
        try
        {
            DoSomething(intarray);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR!!!:{ex}");
        }

        /*
        // try-catch
        try
        {
            // 실행할 것들
            DoSomething(intarray);
        }
        catch (IndexOutOfRangeException ex)
        {
            // 에러 처리
            Console.WriteLine($"에러가 발생했습니다:{ex}");
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine($"다른 에러...{aex}");
        }
        finally
        {
            Console.WriteLine("끝났음.");
        }
        */
    }

    private void DoSomething(int[] ia)
    {
        Console.WriteLine("뭔가 하고있음");
        ia[5] = 0;
    }

    public IEnumerable<int> GetNumber()
    {
        yield return 10;
        yield return 20;
        yield return 30;
    }

    public void DoWhileSample()
    {
        int i = 100;
        Console.Write("Do While:");
        do
        {
            Console.Write($" {i}");
            i++;
        } while (i < 10);
        Console.WriteLine();

        i = 100;
        Console.Write("While:");
        while(i < 10) 
        {
            Console.Write($" {i}");
            i++;
        }
        Console.WriteLine();
    }

    const int MAX_LOOP = 10;
    public void LoopSample()
    {
        // for 감소식 (10...1)
        for (int i = MAX_LOOP; i > 0; i--)
        {
            Console.Write($"Loop{i}>");
        }
        Console.WriteLine();
        // While
        int ii = MAX_LOOP;
        while (ii > 0)
        {
            Console.Write($"While{ii}>");
            ii--;
        }
        Console.WriteLine();

        string[] array = new string[]{"AB","cd","ef"};
        foreach (var item in array)
        {
            //Console.WriteLine(item);
        }

        string[,,] arr = new string[,,]{
            {{"1","2"},{"11","22"}},
            {{"3","4"},{"33","44"}}
        };
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int k = 0; k < arr.GetLength(2); k++)
                {
                    Console.Write($"{arr[i, j, k]} ");
                }
            }
        }
        Console.WriteLine();
        foreach (var item in arr)
        {
            Console.Write($"{item} ");
        }
    }

    static bool verbose = false;
    static bool continueOnError = false;
    static bool logging = false;

    public void SwitchStatement(string[] args)
    {
        string category = "딸기";//string.Empty;
        int price = 100;
        switch (category)
        {
            case "사과":
                price = 1000;
                break;
            case "딸기":
            case "키위":
                price = 1100;
                break;
            case "포도":
                price = 900;
                break;
            default:
                price = 0;
                break;
        }
        /*
        if (category == "사과")
        {
            price = 1000;
        }
        else if (category == "딸기")
        {
            price = 1100;
        }
        else if (category == "포도")
        {
            price = 900;
        }
        else
        {
            price = 0;
        }
        */
        //Console.WriteLine($"Price : {price}");
        if (args.Length != 1)
        {
            Console.WriteLine("Usage:MyApp.exe option");
            return;
        }
        string option = args[0];
        switch (option.ToLower())
        {
            case "/v":
            case "/verbose":
                verbose = true;
                break;
            case "/c":
                continueOnError = true;
                break;
            case "/l":
                logging = true;
                break;
            default:
                Console.WriteLine($"Unknown argument:{option}");
                break;
        }
    }

    public void Operator()
    {
        // 나머지 연산자 %
        int a = (10 + 2 - 1) * (4 / 2) % 3;

        // 할당 연산자 +=, -=, *=, /=, %=
        a %= 2;

        // 증감 연산자
        a++; // a = a + 1 // a += 1
        a--; // a = a - 1 // a -= 1
        
        // 증감연산자를 앞에 붙이냐 뒤에 붙이냐 
        ++a; // 맨먼저 ++ 계산한다

        int b = 1, c = 2;
        bool d = true;
        // 논리 연산자
        if ((a > 1 && b < 0) || c == 1 || !d) a = 0;

        // 비교 연산자
        if (a <= b) a = 0;

        // 비트 연산자
        byte aa = 0b_0000_0111; // 7
        byte bb = (byte)((aa & 3) | 4);
        Console.WriteLine($"byte bb: {bb}");

        // shift 연산자 : << = *2 : >> = /2
        int i = 2;
        i = i << 5;
        Console.WriteLine($"2 after left Shift 5 : {i}");                       

        // 조건 연산자
        int val = (a>b) ? a : b;
        int? iii = null;
        i = iii ?? 0;
        
        string s = null;
        //string ss = s ?? string.Empty;
        string ss;
        if (s == null)
        {
            ss = string.Empty;
        }
        else
        {
            ss = s;
        }
        ss = s ?? "Don't do this";
    }

    enum City
    {
        PyungYang,
        Seoul,
        Deajun,
        Busan = 5,
        Jeju = 10
    }

    [Flags]
    enum Border
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    }

    public void EnumSample()
    {
        City myCity;
        myCity = City.Seoul;
        int cityValue = (int)myCity;
        if (myCity == City.Seoul)
        {
            Console.WriteLine("Welcome to Seoul");
        }

        Border b = Border.Top | Border.Bottom | Border.Left;
        if ((b & Border.Top) != 0)
        {
            if (b.HasFlag(Border.Bottom))
            {
                Console.WriteLine(b.ToString()); // (int)b => 13
            }
        }
    }

    public void StringBuilderSample()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 26; i++)
        {
            sb.Append((char)('A'+ i));
            sb.Append(System.Environment.NewLine);
        }
        string s = sb.ToString();
        Console.WriteLine(s);
    }

    public void StringSample()
    {
        string s1 = "C#";
        string s2 = "Programming";
        //char c1 = 'A';
        //char c2 = 'B';

        string s3 = s1 + " " + s2;
        //Console.WriteLine("String: {1} {0}", s3, 10);
        Console.WriteLine($"String: {10} {s3}");

        string s3substring = s3.Substring(1, 5);
        //Console.WriteLine("Substring: {0}", s3substring);
        Console.WriteLine($"Substring: {s3substring}");

        string s = "C# Studies";
        for (int i = 0; i < s.Length; i++)
        {
            //Console.WriteLine("{0}: {1}", i, s[i]);
            Console.WriteLine($"{i}: {s[i]}");
        }

        string str = "Hello";
        char[] charArray = str.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            Console.WriteLine(charArray[i]);
        }

        char[] charArray2 = {'A','B','C','D'};
        s = new string(charArray2);
        Console.WriteLine(s);

        char c1 = 'A';
        char c2 = (char)(c1 + 3);
        Console.WriteLine(c2);
    }

    public void Dictionary()
    {
        
        // var
        var chr = new List<char>();
        var dic = new Dictionary<int, int>();

        // hashtable
        Hashtable ht = new Hashtable();
        ht.Add("irina", "Irina SP");
        ht.Add("tom", "Tom Cr");

        if (ht.Contains("tom"))
        {
            Console.WriteLine(ht["tom"]);
        }

        // dictionary
        Dictionary<int, string> emp = new Dictionary<int, string>();
        emp.Add(1001, "Jane");
        emp.Add(1002, "Tom");
        emp.Add(1003, "Cindy");
        
        Console.WriteLine("Count:" + emp.Count);

        string name = emp[1002];
        Console.WriteLine(name);
        if (emp.ContainsKey(1004))
        {
            name = emp[1004];
            Console.WriteLine(name);
        }
    }

    public void Queue_Stack()
    {
        // Queue
        Queue<int> q = new Queue<int>();

        q.Enqueue(120);
        q.Enqueue(130);
        q.Enqueue(150);

        int next = q.Dequeue();
        Console.WriteLine("Next:" + next);
        Console.WriteLine("Count:" + q.Count);
        next = q.Dequeue();
        Console.WriteLine("Next:" + next);

        // Stack
        Stack<float> s = new Stack<float>();

        s.Push(10.5f);
        s.Push(3.54f);
        s.Push(4.22f);

        float val = s.Pop();
        Console.WriteLine("val:" + val);
        Console.WriteLine("Count:" + s.Count);
    }

    public void List()
    {
        List<int> intlist = new List<int>();
        List<char> charlist = new List<char>();
        List<float> flist = new List<float>();
        List<bool> blist = new List<bool>();
        List<string> slist = new List<string>();

        intlist.Add(0);
        intlist.Add(2);
        intlist.Add(0);

        // Remove는 리스트의 처음부터 검사해서 
        // 해당하는 아이템이 있다면 그것만 지운다
        intlist.Remove(0);
        
        // 배열에서는 .Length
        // 리스트에서는 .Count 로 크기를 구할 수 있다
        int val = intlist.Count;
        Console.WriteLine("intlist의 크기:" + val);

        // linked list
        LinkedList<string> list = new LinkedList<string>();
        list.AddLast("Apple");
        list.AddLast("Banana");
        list.AddLast("Lemon");

        LinkedListNode<string> node = list.Find("Banana");
        LinkedListNode<string> newNode = new LinkedListNode<string>("Grape");

        list.AddAfter(node, newNode);

        list.ToList<string>().ForEach(p => Console.WriteLine(p));

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public void Array()
    {
        // 1
        string[] players = new string[10];
        Console.WriteLine("players:" + players.Length);
        int[] intarray = new int[100];
        Console.WriteLine("intarry:" + intarray.Length);
        char[] cc = new char[5];
        int[] abc = new int[3];
        int[] abc2 = new int[3]{1,2,3};
        string[] Regions = new string[3]{"seoul", "kk", "busan"};

        // 2
        string[,] Depts = new string[2,2];
        Console.WriteLine("Depts:" + Depts.Length);
        int[,] inta2 = new int[3,2]{{1,2},{2,3},{3,4}};
        Console.WriteLine("inta2:" + inta2.Length);

        // 3
        string[,,] Cubes = new string[2,3,4];
        Console.WriteLine("Cubes:" + Cubes.Length);

        // 아래 방법은 가능하지만, 2차원 배열[,]을 사용하자
        // 차원별 배열 크기가 다를 경우 사용
        int[][] ii = new int[2][]; 
        int[][] iii = new int[3][];
        iii[0] = new int[2]{1,2};
        iii[1] = new int[2]{2,3};
        iii[2] = new int[2]{3,4};

        // for
        int sum = 0;
        int[] scores = new int[5]{80,78,60,90,100};
        // sum += scores[0];
        // sum += scores[1];
        // sum = sum + scores[2];
        // sum = sum + scores[3];
        // sum = sum + scores[4];
        for (int i = 0; i < scores.Length; i++)
        {
            // sum = sum + scores[i];
            // sum -= scores[i];
            // sum *= scores[i];
            // sum /= scores[i];
            sum += scores[i];
        }
        Console.WriteLine("sum : " + sum);

        int[] ss = new int[100];
        ss[0] = 90;
        int val = ss[0];
    }

    public void RandomSum()
    {
        // random
        int sum = 0;
        int[] nums = new int[10];

        Random rand = new Random();
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = rand.Next() % 100;
            Console.WriteLine("nums["+i+"]:" + nums[i]);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        Console.WriteLine(sum);
    }

    void DataType()
    {
        // Bool
        bool b = true;
        // Numeric
        short sh = -32768;
        uint i = 2147483649;
        long l = 1234L;
        float f = 123.45f;
        double d1 = 123.45;
        double d2 = 123.45d;
        decimal d = 123.45M;
        // Char/String
        char c = 'A';
        string s = "Hello";
        s = null;

        // == !=
        if (s[0] != 'e') 
            b = true;
        else 
            b = false;

        //DateTime
        DateTime dt = new DateTime(2025, 1, 13, 10, 24, 00);

        // max, min
        int i2 = 0;
        // ....
        //if (i2 > 2147483647) ;
        if (i2 > int.MaxValue) ;

        // 기억해야 되는 datatype
        bool bb = false;
        int i3 = 0;
        float ff = 0.1f;
        char cc = 'c';
        string ss = "hello world";
    }
}