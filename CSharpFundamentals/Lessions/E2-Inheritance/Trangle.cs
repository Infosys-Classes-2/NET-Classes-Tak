using System;
public class Trinagle: IShape
{
    public Trinagle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
    private double a;
    private double b;
    private double c;

    public double GetParimeter() => a+b+c;
    public double GetArea()
    {
        var s = GetParimeter()/2;
        var area = Math.Sqrt(s*(s-a)*(s-b)*(s-c));
        return area;
    }
}