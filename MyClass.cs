class MyClass
{
    private const int MAX = 10;
    private string name;
    private int[] data = new int[MAX];
    private int val = 1;

    public int InstRun()
    {
        return val;
    }

    public static int Run()
    {
        return 1;
    }

    public void SetName(string strName)
    {
        name = strName;
    }

    // indexer
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= MAX)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return data[index];
            }
        }
        set
        {
            if (!(index < 0 || index >= MAX))
            //if (index >= 0 && index < MAX)
            {
                data[index] = value;
            }
        }
    }

    public int this[string str]
    {
        get
        {
            if (str.Equals(name))
            {
                return data[0];
            }
            else
            {
                throw new Exception();
            }
        }
        set
        {
            if (str.Equals(name))
            {
                data[0] = value;
            }
        }
    }
}

public class Client
{
    public void Test()
    {
        MyClass myClass = new MyClass();
        int i = myClass.InstRun();

        int j = MyClass.Run();
    }
}

public static class MyUtility
{
    private static int ver;

    static MyUtility()
    {
        ver = 1;
    }

    public static string Convert(int i)
    {
        return i.ToString();
    }

    public static int ConvertBack(string s)
    {
        return int.Parse(s);
    }

}