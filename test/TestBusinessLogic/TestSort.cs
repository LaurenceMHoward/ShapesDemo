using BusinessLogic.Interfaces;

namespace TestBusinessLogic;

using BusinessLogic.Generating;
using BusinessLogic.Sorting;
using FluentAssertions;

public class TestSort
{
    private readonly CollectionFactory _collectionGenerator = new();
    private readonly IShapeSorter _sut = new ShapeSorter();

    public TestSort()
    {
        _sut.Shapes = _collectionGenerator.CreateShapeCollection(10);
    }

    [Fact]
    public void SortShapesByAreaAscending_Success()
    {
        _sut.SortList(SortLogic.ByArea, SortLogic.Ascending);
        _sut.Shapes[0].Area.Should().BeLessThan(_sut.Shapes[9].Area);
        _sut.Shapes.Count.Should().Be(10);
    }

    [Fact]
    public void SortShapesByAreaDescending_Success()
    {
        _sut.SortList(SortLogic.ByArea, SortLogic.Descending);
        _sut.Shapes[0].Area.Should().BeGreaterThan(_sut.Shapes[9].Area);
        _sut.Shapes.Count.Should().Be(10);
    }

    [Fact]
    public void SortShapesByPerimeterAscending_Success()
    {
        _sut.SortList(SortLogic.ByPerimeter, SortLogic.Ascending);
        _sut.Shapes[0].Perimeter.Should().BeLessThan(_sut.Shapes[9].Perimeter);
        _sut.Shapes.Count.Should().Be(10);
    }

    [Fact]
    public void SortShapesByPerimeterDescending_Success()
    {
        _sut.SortList(SortLogic.ByPerimeter, SortLogic.Descending);
        _sut.Shapes[0].Perimeter.Should().BeGreaterThan(_sut.Shapes[9].Perimeter);
        _sut.Shapes.Count.Should().Be(10);
    }
}