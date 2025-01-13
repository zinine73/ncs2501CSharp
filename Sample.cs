class Sample
{

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