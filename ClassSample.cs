// Base class
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    protected float size = 10.2f;
    public void ShowSize()
    {
    }
    
    public void SetSize(float value)
    {
        this.size = value;
    }
}

// child class
public class Dog : Animal
{
    public void HowOld()
    {
        Console.WriteLine($"Age : {this.Age}");
    }

    public new void ShowSize()
    {
        Console.WriteLine($"{Name} size is {base.size}");
    }
}

public class Bird : Animal
{
    public void Fly()
    {
        Console.WriteLine($"{this.Name} is flying");
    }
}

public class NewPices : Dog
{

}

public abstract class PureBase
{
    public abstract int GetFirst();
    public abstract int GetNext();
}

public class ChildA : PureBase
{
    private int no = 1;
    public override int GetFirst()
    {
        return no;
    }
    public override int GetNext()
    {
        return ++no;
    }
}