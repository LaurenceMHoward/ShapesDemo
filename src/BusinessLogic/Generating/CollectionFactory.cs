namespace BusinessLogic.Generating;

using Interfaces;
using Shapes.Helpers;
using Shapes.Shapes;

public class CollectionFactory : ICollectionFactory
{
    private readonly Random _random = new();
    private readonly ICounters _counters;

    public CollectionFactory(ICounters counters)
    {
        this._counters = counters;
    }

    public List<Shape> CreateShapeCollection(int count)
    {
        var collection = new List<Shape>();
        for (int i = 0; i < count; ++i)
        {
            collection.Add(GenerateSingleRandomShape());
        }

        return collection.ToList();
    }

    private Shape GenerateSingleRandomShape()
    {
        int rand = _random.Next(0, 3);
        Shape s;
        switch (rand)
        {
            case 0:
                double radius = _random.NextDouble() * (10 - 1) + 1;
                var circle = new Circle();
                circle.PopulateCircle(radius);
                s = circle;
                _counters.Circles++;
                break;

            case 1:
                // loop to make sure randomized triangle generation is a valid triangle
                Triangle triangle;
                do
                {
                    double b = _random.NextDouble() * 10;
                    double a = _random.NextDouble() * 5;
                    double c = _random.NextDouble() * 5;
                    triangle = new Triangle();
                    triangle.PopulateTriangle(b, a, c);
                } while (triangle.Area <= 0 || double.IsNaN(triangle.Area));

                s = triangle;
                _counters.Triangles++;
                break;

            default:
                double l = _random.NextDouble() * (10 - 1) + 1;
                double w = _random.NextDouble() * (10 - 1) + 1;
                var quad = new Quadrilateral();
                quad.PopulateQuadrilateral(w, l);
                s = quad;
                _counters.Quadrilaterals++;
                break;
        }

        return s;
    }
}