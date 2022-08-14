//Obj oriented concept came for Rear life implimentation
// Animal 
using System;
namespace AboutClasses; // namespace for grouping
class Animal1
{
    //Memvbers: Fields, methods
    // Acccss modifiers: public, private, internal, protected
    public float weight;
    internal string type;

    void Eat()
    {
        Console.WriteLine(type + " is eating.");
    }

    internal void PrintDetails()
    {
        Eat();
        Console.WriteLine($"Weight of {type} is {weight}");
    }
}
