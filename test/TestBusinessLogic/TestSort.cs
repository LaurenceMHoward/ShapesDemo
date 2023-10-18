using BusinessLogic.Interfaces;

namespace TestBusinessLogic;

using BusinessLogic.Flight;
using BusinessLogic.Generating;
using FluentAssertions;

public class TestSort
{
    private readonly List<string> _rectNames = new() { "Square", "Rectangle" };
    private readonly IShapeSorter _sut;

    public TestSort()
    {
        ICounters counters = new Counters();
        ICollectionFactory collectionGenerator = new CollectionFactory(counters);
        _sut = new ShapeSorter(counters);
        _sut.Shapes = collectionGenerator.CreateShapeCollection(10);
    }

    [Fact]
    public void SortShapesByAreaAscending_ShapeCountsReturned_Success()
    {
        _sut.SortList(SortLogic.ByArea, SortLogic.Ascending);
        _sut.Shapes[0].Area.Should().BeLessThan(_sut.Shapes[9].Area);
        _sut.Shapes.Count.Should().Be(10);
        var items = _sut.GetShapesCount();
        items.Triangles.Should().Be(_sut.Shapes.Count(x => x.Name.Contains("Triangle")));
        items.Circles.Should().Be(_sut.Shapes.Count(x => x.Name.Contains("Circle")));
        items.Quadrilaterals.Should().Be(_sut.Shapes.Count(x => _rectNames.Contains(x.Name)));
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