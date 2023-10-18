namespace BusinessLogic.Sorting;

using Interfaces;
using Shapes.Shapes;

public class ShapeSorter : IShapeSorter
{
    public List<Shape> Shapes { get; set; } = new();

    public void SortList(SortLogic sortParameter = SortLogic.ByPerimeter, SortLogic sortDirection = SortLogic.Descending)
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