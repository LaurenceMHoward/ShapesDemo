using Shapes.Shapes;

namespace BusinessLogic.Interfaces;

public interface IXmlExporter
{
    public bool ExportShapeCollection(List<Shape> shapes, string path = "./");
}