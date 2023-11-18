namespace Shapes.Helpers;

using Shapes;

public static class ShapeHelper
{
    public static int DecimalPlaces { get; set; } = 2;
    public static double Pi => Math.PI.SetPrecision();

    public static void PopulateCircle(this Circle circle, double radius)
    {
        circle.Name = "Circle";
        circle.Radius = radius;
        circle.Area = (Pi * circle.Radius * circle.Radius).SetPrecision();
        circle.Perimeter = (2 * Pi * circle.Radius).SetPrecision();
    }

    public static void PopulateQuadrilateral(this Quadrilateral quad, double width, double length)
    {
        quad.Width = width;
        quad.Length = length;
        quad.Area = (width * length).SetPrecision();
        quad.Perimeter = ((width + length) * 2).SetPrecision();
        quad.Name = Math.Abs(width - length) == 0 ? "Square" : "Rectangle";
    }

    public static void PopulateTriangle(this Triangle triangle, double triangleBase, double sideOne, double sideTwo)
    {
        // for ease of generation this
        triangle.Base = triangleBase;
        triangle.SideOne = sideOne;
        triangle.SideTwo = sideTwo;

        double s = (triangle.Base + triangle.SideOne + triangle.SideTwo) / 2;
        double height = Math.Sqrt(s * (s - triangle.SideOne) * (s - triangle.Base) * (s - triangle.SideTwo));
        triangle.Perimeter = (triangle.Base + triangle.SideOne + triangle.SideTwo).SetPrecision();
        triangle.Area = (height * triangle.Base / 2).SetPrecision();

        if (Math.Abs(triangle.Base - triangle.SideOne) == 0 &&
            Math.Abs(triangle.SideOne - triangle.SideTwo) == 0)
        {
            triangle.Name = "Equilateral Triangle";
        }
        else if (Math.Abs(triangle.Base - triangle.SideOne) == 0 ||
                 Math.Abs(triangle.SideOne - triangle.SideTwo) == 0 ||
                 Math.Abs(triangle.Base - triangle.SideTwo) == 0)
        {
            triangle.Name = "Scalene Triangle";
        }
        else
        {
            triangle.Name = "Isosceles Triangle";
        }
    }

    public static double SetPrecision(this double value)
    {
        return Math.Round(value, DecimalPlaces, MidpointRounding.AwayFromZero);
    }
}