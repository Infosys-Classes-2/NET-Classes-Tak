using System;
public class Test
{
    void CalculateArea()
    {
        IShape rect1 = new Ractangle(23.4, 12.5);
        var area = rect1.GetArea();
        var per1 = rect1.GetParimeter();

        IShape square1 = new Square(56.4);
        var area2 = square1.GetArea();
        var per2 = square1.GetParimeter();

        IShape traiangle1 = new Trinagle(23.4, 56.1, 12.7);
        var area3 = traiangle1.GetArea();
        var par3 = traiangle1.GetParimeter();
    }
}