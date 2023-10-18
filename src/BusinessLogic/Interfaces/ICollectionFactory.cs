using Shapes.Shapes;

namespace BusinessLogic.Interfaces;

public interface ICollectionFactory
{
    public List<Shape> CreateShapeCollection(int count);
}