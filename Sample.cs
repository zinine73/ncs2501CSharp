using System.Collections;

class Sample
{
    
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