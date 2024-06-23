using BusinessLogic.Interfaces;

namespace TestBusinessLogic;

using BusinessLogic.Flight;
using BusinessLogic.Generating;
using FluentAssertions;

public class TestSort
{
    private readonly List<string> _rectNames = ["Square", "Rectangle"];
    private readonly ShapeSorter _sut;

    public TestSort()
    {
        ICounters counters = new Counters();
        CollectionFactory collectionGenerator = new(counters);
        _sut = new ShapeSorter(counters)
        {
            Shapes = collectionGenerator.CreateShapeCollection(10)
        };
    }

    [Fact]
    public void SortShapesByAreaAscending_ShapeCountsReturned_Success()
    {
        _sut.SortList(SortLogic.ByArea, SortLogic.Ascending);
        _sut.Shapes[0].Area.Should().BeLessThan(_sut.Shapes[9].Area);
        _sut.Shapes.Count.Should().Be(10);
        (int circles, int triangles, int quadrilaterals) = _sut.GetShapesCount();
        triangles.Should().Be(_sut.Shapes.Count(x => x.Name.Contains("Triangle")));
        circles.Should().Be(_sut.Shapes.Count(x => x.Name.Contains("Circle")));
        quadrilaterals.Should().Be(_sut.Shapes.Count(x => _rectNames.Contains(x.Name)));
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