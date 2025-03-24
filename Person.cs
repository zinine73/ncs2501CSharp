class Person
{
    private string name = "Kim";

    public Person()
    {
    }
    public Person(string name) => this.name = name;
}

class Foo
{
    public string name;
    public int value;

    public Foo(){}

    public Foo(string name) => this.name = name;

    ~Foo()
    {
    }
}