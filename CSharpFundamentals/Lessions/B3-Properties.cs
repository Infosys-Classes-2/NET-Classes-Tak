// Properties is member of class.
namespace AboutClass;
public class Plannet
{
    private string name;

    // Full property
    public string Name // properties define
    {
        get
        {
            return name;
        }
        set
        {
            if(value.Length > 0)
            name = value;

        }
    }
    /*
     private double mass;
    public double mass // properties define
    {
        get
        {
            return name;
        }
        set
        {
            if(value.Length > 0)
            name = value;

        }
    }
    */
    // Auto-implemented property.
    //public double Mass {get; private set;}
    public double Mass {get;  set;}

    // Read-only property
    //public double DistanceFromSun { get; } = 234.56; // value initialized
    public double DistanceFromSun { get; }
    
    public void ValidateName(string n)
    {
        if(n.Length > 0)
            name = n;
    }
}

public class Test2
{
    void Do()
    {
        Plannet earth = new();
        //earth.ValidateName("");
        earth.Name = "Earth";

        var x = earth.Name;
    }
}