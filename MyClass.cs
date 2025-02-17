class MyClass
{
    private const int MAX = 10;
    private string name;

    private int[] data = new int[MAX];

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