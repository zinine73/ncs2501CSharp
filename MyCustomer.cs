public class MyCustomer
{
    // field : 되도록이면 private으로 
    //public long yearmoney;
    private long yearMoney;
    private string name;
    private int age;

    /*
    public long YearMoney()
    {
        return yearmoney;
    }
    public void YearMoney(long val)
    {
        yearmoney = val;
    }
    public int Age()
    {
        return this.age;
    }
    public void Age(int val)
    {
        this.age = val;
    }
    */
    // event
    public event EventHandler NameChanged;
    // 생성자
    public MyCustomer()
    {
        Init(string.Empty, -1);
    }
    public MyCustomer(int val)
    {
        Init(string.Empty, val);
    }
    /// <summary>
    /// 초기화
    /// </summary>
    /// <param name="str">이름</param>
    /// <param name="val">나이</param>
    public void Init(string str, int val)
    {
        name = str;
        age = val;
    }
    // 속성(property)
    public string Name // 이름
    {
        get { return this.name;}
        set
        {
            if (this.name != value)
            {
                this.name = value;
                if (NameChanged != null)
                {
                    NameChanged(this, EventArgs.Empty);
                }
            }
        }
    }
    /*
    public int Age
    {
        //get { return this.age; }
        //set { this.age = value; }
        // 아래 형태로 생략해서 사용 가능
        get;
        set;
    }
    */
    // 아래는 age가 아니라 Age라는 변수처럼 사용됨
    public int Age { get; set; }

    /// <summary>
    /// 연봉
    /// </summary>
    public long YearMoney
    {
        get { return this.yearMoney; }
        set 
        {
            if (value < 0)
            {
                Console.WriteLine($"음수는 안됩니다.");
            }
            else
            {
                yearMoney = value;
            }
        }
    }
    // 메서드(method)
    // 고객 정보 얻어오기
    public string GetCustomerData()
    {
        string data = string.Format("Name: {0} (Age: {1})",
                    this.Name, this.Age);
        return data;
    }

    /*
    public void SetYearMoney(long val)
    {
        if (val < 0)
        {
            Console.WriteLine($"음수는 안됩니다.");
        }
        else
        {
            yearmoney = val;
        }
    }
    */

    /// <summary>
    /// 연봉을 출력
    /// </summary>
    public void printYearMoney()
    {
        Console.WriteLine(yearMoney);
    }
}