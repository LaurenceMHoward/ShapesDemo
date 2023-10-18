using System.Xml.Serialization;

namespace Shapes.Shapes;

[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Triangle))]
[XmlInclude(typeof(Quadrilateral))]
public abstract class Shape
{
    [XmlAttribute("Area")] public double Area { get; set; }

    [XmlAttribute("Name")] public string Name { get; set; } = string.Empty;

    [XmlAttribute("Perimeter")] public double Perimeter { get; set; }
}