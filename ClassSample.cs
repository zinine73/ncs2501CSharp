using System.Diagnostics;
using System;

public partial class Class2
{
    partial void DoThis()
    {
        var a = DateTime.Now;
    }
}

partial class Class1
{
    public void Get() {}
}

partial class Class1
{
    public void Put() {}
}

partial struct Struct1
{
    public string Name;

    public Struct1(int id, string name)
    {
        this.ID = id;
        this.Name = name;
    }
}

partial interface IDoable
{
    void Do();
}

// interface
public interface IComparable
{
    int CompareTo(object obj);
}

public class MyClass2 : IComparable
{
    private int key;
    private int value;

    public int CompareTo(Object obj)
    {
        MyClass2 target = (MyClass2)obj;
        return this.key.CompareTo(target.key);
    }
}

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