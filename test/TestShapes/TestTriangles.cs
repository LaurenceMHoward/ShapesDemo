using Shapes.Shapes;

namespace TestShapes;

using FluentAssertions;
using Shapes.Helpers;

public class TestTriangles
{
    [Theory]
    [InlineData(4, 3, 6, "Isosceles Triangle", 13, 10.67)]
    [InlineData(3, 3, 3, "Equilateral Triangle", 9, 5.85)]
    [InlineData(4, 3, 3, "Scalene Triangle", 10, 8.94)]
    [InlineData(4.001, 3.001, 3.001, "Scalene Triangle", 10, 8.95)]
    [InlineData(1, 2, 2, "Scalene Triangle", 5, 0.48)]
    public void Triangle_generatesCorrectDimensions_AndName_WithCorrect_Precision_Success(double side0, double side1,
        double side2, string name, double perimeter, double area)
    {
        var test = new Triangle();
        test.PopulateTriangle(side0, side1, side2);

        test.Base.Should().Be(side0);
        test.SideOne.Should().Be(side1);
        test.SideTwo.Should().Be(side2);

        test.Perimeter.Should().Be(perimeter);
        test.Area.Should().Be(area);
        test.Name.Should().Be(name);
    }
}