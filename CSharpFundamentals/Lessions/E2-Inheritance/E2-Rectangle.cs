// area and perimeter finding
public class Ractangle : IShape
{
    public Ractangle(double l, double b)
    {
        length = l;
        breadth = b;
    }
    private double length;
    private double breadth;

    public double GetArea() => length * breadth;
    /*
    public double GetArea()
    {
        return length * breadth;
    }
    */
    public double GetParimeter() => 2 * (length+breadth);
}