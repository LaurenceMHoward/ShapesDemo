namespace BusinessLogic.Generating;

using Interfaces;
using Shapes.Helpers;
using Shapes.Shapes;

public class CollectionFactory(ICounters counters) : ICollectionFactory
{
    private readonly Random _random = new();

    public List<Shape> CreateShapeCollection(int count)
    {
        List<Shape> collection = [];
        for (int i = 0; i < count; ++i)
        {
            collection.Add(GenerateSingleRandomShape());
        }

        return collection;
    }

    private Shape GenerateSingleRandomShape()
    {
        int rand = _random.Next(0, 3);
        Shape s;
        switch (rand)
        {
            case 0:
                double radius = _random.NextDouble() * (10 - 1) + 1;
                Circle circle = new();
                circle.PopulateCircle(radius);
                s = circle;
                counters.Circles++;
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
                } while (triangle.Area is <= 0 or Double.NaN);

                s = triangle;
                counters.Triangles++;
                break;

            default:
                double l = _random.NextDouble() * (10 - 1) + 1;
                double w = _random.NextDouble() * (10 - 1) + 1;
                Quadrilateral quad = new();
                quad.PopulateQuadrilateral(w, l);
                s = quad;
                counters.Quadrilaterals++;
                break;
        }

        return s;
    }
}