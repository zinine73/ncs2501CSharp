class Sample
{
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