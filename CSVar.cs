class CSVar
{
    // field(필드) : 전역변수
    int glovalVar = 0;
    const int MAX = 1024;

    public void Method1()
    {
        // 지역변수
        int localVar = 0;

        localVar = 100;
        int max = 500;

        if (max < MAX)
        {
            Console.WriteLine(glovalVar);
            Console.WriteLine(localVar);
        }
    }
}