namespace Members;
//public abstract class Person
public class Person
{
    public double age; //instance member
    public string Name {get; set;}
    public static byte noOfEyes; //to call no need create object

    public void PrintDetails()
    {

    }
}

public class Test
{
    public void Do()
    {
        Person p1 = new();
        p1.age = 45; //

        Person.noOfEyes = 2;
    }
}

// to define base class we use abstract class.
// public abstract class Person => object banauna didaina.