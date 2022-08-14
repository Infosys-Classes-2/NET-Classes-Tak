using System;

public class LivingThing
{
    public string food;
    public string scientificName;

    public void Eat()
    {
        Console.WriteLine($"I am eating {food}");
    }
}

public class Plant : LivingThing
{
    public bool flowering;
    public int leafCount;

    public void PrintPlantDetail()
    {
        var x = flowering ? "flowering" : "non-flowering";
        Console.WriteLine($"I am {x} plant.");
    }
}

public class Animal : LivingThing
{
    public byte noOfLegs;
    public AnimalCategory type;

    public void PrintAnimalDetail()
    {
        var x = type == AnimalCategory.Vertibrates ? "bones" : "no bones";
        Console.WriteLine("I have {x}");
    }
}

public class Human : Animal
{

}

public class YarsaGumba : Plant, IAnimal
{
    public void PrintAnimalDetail()
    {

    }
}

public interface IAnimal
{
    public void PrintAnimalDetail();
}

public enum AnimalCategory
{
    Vertibrates,
    Invertibrates
}

// L, P <- L, A <- L - Single inheritance
// L, A <- L, H <- A - Multi-level inheritance
// A, IA, Y <- A, IA - Multiple inheritance