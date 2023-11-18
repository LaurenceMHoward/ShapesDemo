namespace BusinessLogic.Flight;

using Interfaces;
using Shapes.Shapes;

public class ShapeSorter(ICounters counters) : IShapeSorter
{
    public List<Shape> Shapes { get; set; } = [];

    public (int Circles, int Triangles, int Quadrilaterals) GetShapesCount()
    {
        return (counters.Circles, counters.Triangles, counters.Quadrilaterals);
    }

    public void SortList(SortLogic sortParameter = SortLogic.ByPerimeter,
        SortLogic sortDirection = SortLogic.Descending)
    {
        switch (sortParameter)
        {
            case SortLogic.ByArea:
                if (sortDirection == SortLogic.Descending)
                {
                    Shapes.Sort((x, y) => y.Area.CompareTo(x.Area));
                }
                else
                {
                    Shapes.Sort((x, y) => x.Area.CompareTo(y.Area));
                }

                break;

            default:
                if (sortDirection == SortLogic.Descending)
                {
                    Shapes.Sort((x, y) => y.Perimeter.CompareTo(x.Perimeter));
                }
                else
                {
                    Shapes.Sort((x, y) => x.Perimeter.CompareTo(y.Perimeter));
                }

                break;
        }
    }
}