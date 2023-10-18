using System.Xml;

namespace BusinessLogic.Output;

using System.Xml.Serialization;
using Interfaces;
using Shapes.Shapes;

public class XmlExporter : IXmlExporter
{
    public bool ExportShapeCollection(List<Shape> shapes, string path = "./")
    {
        // convert
        string content = XmlContentConverter(shapes);
        // save to file
        if (Directory.Exists(path))
        {
            // for simplicity
            string filePath = Path.Combine(path, "exported Shapes.xml");
            File.WriteAllText(filePath, content);
        }

        return true;
    }

    private static string XmlContentConverter<T>(List<T> items) where T : Shape
    {
        XmlSerializer serializer = new(typeof(List<T>));

        using StringWriter sw = new();
        using (XmlWriter xw = new XmlTextWriter(sw))
        {
            serializer.Serialize(xw, items);
        }

        return sw.ToString();
    }
}