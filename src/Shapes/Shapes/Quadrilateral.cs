using System.Xml.Serialization;
using Shapes.Helpers;

namespace Shapes.Shapes;

[XmlRoot("Quadrilateral")]
public class Quadrilateral : Shape
{
    [XmlAttribute("Length")] public double Length { get; set; }

    [XmlAttribute("Width")] public double Width { get; set; }
}