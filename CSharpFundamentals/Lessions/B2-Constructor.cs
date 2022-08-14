using System;
namespace AoutClass;
public class Shape2D
{    
    // Default constructor - parameterless
    public Shape2D()
    {        
    }

    // Parameterized constructor
    public Shape2D(string n)
    {
        name = n;
    }

    private string name;
    public void PrintDetail()
    {    
        Console.WriteLine($"I am {name}");    
    }
}