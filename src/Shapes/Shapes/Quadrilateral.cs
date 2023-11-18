using System.Xml.Serialization;

namespace Shapes.Shapes;

[XmlRoot("Quadrilateral")]
public sealed class Quadrilateral : Shape
{
    [XmlAttribute("Length")] public double Length { get; set; }

    [XmlAttribute("Width")] public double Width { get; set; }
}