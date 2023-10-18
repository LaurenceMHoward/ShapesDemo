namespace TestShapes;

using FluentAssertions;
using Shapes.Helpers;

public class TestHelpers
{
    [Fact]
    public void TestHelper_GetPi_ToTwoDecimalPlace_Success()
    {
        double piShort = ShapeHelper.Pi;
        piShort.Should().Be(3.14d);
    }

    [Fact]
    public void TestHelper_SetPrecision_ToTwoDecimalPlace_AdjustDown_Success()
    {
        double result = 9.484956545656345623.SetPrecision();

        result.Should().Be(9.48d);
    }

    [Fact]
    public void TestHelper_SetPrecision_ToTwoDecimalPlace_AdjustUp_Success()
    {
        double result = 9.988956545656345623.SetPrecision();

        result.Should().Be(9.99d);
    }
}