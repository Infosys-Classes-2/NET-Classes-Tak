// Type parameter
using   System;
using System.Collections.Generic;

public class Generac
{
    public void Print<T>(T x)
    {
        Console.WriteLine(x);
    }
    /*
    public void Print(string greeting)
    {
        Console.WriteLine(greeting);
    }
    public void Print(float x)
    {
        Console.WriteLine(x);
    }

    public void Print(bool x)
    {
        Console.WriteLine(x);
    }
    */
}

class Test4
{
    void Test()
    {
        Generac g = new();
        g.Print<string>("Hey there!! How are you?");
        g.Print<float>(4753.45f);
        g.Print(true);

        List<int> numbers = new List<int>();
        List<string> strings = new List<string>();
    }
}