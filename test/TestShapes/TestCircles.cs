namespace TestShapes;

using FluentAssertions;
using Shapes.Helpers;
using Shapes.Shapes;

public class TestCircles
{
    [Theory]
    [InlineData(4, 25.12, 50.24)]
    [InlineData(4.1, 25.75, 52.78)]
    [InlineData(4.4, 27.63, 60.79)]
    [InlineData(4.8, 30.14, 72.35)]
    [InlineData(5, 31.40, 78.50)]
    [InlineData(5.03, 31.59, 79.44)]
    [InlineData(5.09, 31.97, 81.35)]
    [InlineData(5.27, 33.10, 87.21)]
    public void Circle_generatesCorrectDimensions_AndName_WithExpectedPrecision_Success(double radius, double perimeter,
        double area)
    {
        var test = new Circle();
        test.PopulateCircle(radius);

        test.Radius.Should().Be(radius);
        test.Perimeter.Should().Be(perimeter);
        test.Area.Should().Be(area);
        test.Name.Should().Be("Circle");
    }
}