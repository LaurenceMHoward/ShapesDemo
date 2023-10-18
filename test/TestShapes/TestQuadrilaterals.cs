using FluentAssertions;
using Shapes.Shapes;

namespace TestShapes;

using Shapes.Helpers;

public class TestQuadrilaterals
{
    [Theory]
    [InlineData(4, 3, "Rectangle", 14, 12)]
    [InlineData(3, 3, "Square", 12, 9)]
    [InlineData(9.1, 9.01, "Rectangle", 36.22, 81.99)]
    [InlineData(1.1, 1.001, "Rectangle", 4.2, 1.1)]
    [InlineData(1.1, 1.01, "Rectangle", 4.22, 1.11)]
    [InlineData(1.01, 1.0058, "Rectangle", 4.03, 1.02)]
    [InlineData(1.01, 1.0144, "Rectangle", 4.05, 1.02)]
    [InlineData(1.01, 1.015, "Rectangle", 4.05, 1.03)] // will actually be 1.0149999999999999 as double
    public void Quadrilateral_generatesCorrectDimensions_AndName_WithCorrect_Precision_Success(double width,
        double length, string name, double perimeter, double area)
    {
        var test = new Quadrilateral();
        test.PopulateQuadrilateral(width, length);

        test.Width.Should().Be(width);
        test.Length.Should().Be(length);

        test.Perimeter.Should().Be(perimeter);
        test.Area.Should().Be(area);
        test.Name.Should().Be(name);
    }
}