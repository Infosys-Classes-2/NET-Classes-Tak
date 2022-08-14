// Polymorphism
// Static - Method Overloading
// Dynamic - Method overriding

using System;
public class Vehicle
{
    public virtual void Start() // virtual diya pachi override garna sakinchha.
    {
        Console.WriteLine("Engine started");
    }
     public void Start(float voltage)
    {
        Console.WriteLine($"Engine started with prescirbed voltage {voltage}");
    }
}

public class Car: Vehicle
{
    public override void Start()
    {
        base.Start(); // base method override.
        //Console.WriteLine ("Car engine Started.");
        Console.WriteLine ("It's a car.");
    }
    public new void Start(float voltage) // overriding withoud vertual word 
    {
        Console.WriteLine($"Engine started with prescribed ..");
    }
}

class Test1
{
    void Do()
    {
        Car c1 = new();
        c1.Start();
    }

    //overriding other method
}